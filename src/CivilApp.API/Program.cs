using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using CivilApp.Core.Configuration;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Serilog;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using Serilog.Exceptions.SqlServer.Destructurers;
using Serilog.Sinks.MSSqlServer;

namespace CivilApp.API
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables("civilapp_")
            .AddKeyPerFile("/run/secrets")
            .Build();

        public static void Main(string[] args)
        {
            var logConnectionString = ConnectionStringBuilder.BuildSQLConnectionString(Configuration.GetValue<string>("DATABASE_SERVER"), Configuration.GetValue<string>("DATABASE"), Configuration.GetValue<string>("CIVILAPP_USERNAME"), Configuration.GetValue<string>("CIVILAPP_PASSWORD"));
            var colOpts = new ColumnOptions();
            colOpts.Store.Remove(StandardColumn.Properties);
            colOpts.Store.Add(StandardColumn.LogEvent);
            colOpts.AdditionalColumns = new List<SqlColumn>
            {
                new SqlColumn() { ColumnName = "Source", DataType = System.Data.SqlDbType.VarChar, PropertyName = "SourceContext", AllowNull = false, DataLength = 250 }
            };

            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));

            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(Configuration)
                    .Enrich.FromLogContext()
                    .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
                        .WithDefaultDestructurers()
                        .WithDestructurers(new[] { new SqlExceptionDestructurer() }))
                    .WriteTo.Debug()
                    .WriteTo.Console(
                        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
                    .WriteTo.MSSqlServer(
                        connectionString: logConnectionString,
                        sinkOptions: new MSSqlServerSinkOptions()
                        {
                            SchemaName = "Logging",
                            TableName = "CivilAppLogs",
                            AutoCreateSqlTable = true
                        },
                        columnOptions: colOpts
                    )
                    .CreateLogger();

            try
            {
                Log.Information("Application starting");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
