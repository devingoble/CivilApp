using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            .AddEnvironmentVariables()
            .Build();

        public static void Main(string[] args)
        {
            var logDB = Configuration.GetConnectionString("SerilogConnection");
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
                        connectionString: logDB,
                        sinkOptions: new MSSqlServerSinkOptions()
                        {
                            SchemaName = "Logging",
                            TableName = "RMSReports",
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
