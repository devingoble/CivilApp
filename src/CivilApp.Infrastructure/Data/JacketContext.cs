using Ardalis.Specification;

using CivilApp.Core.Entities.JacketAggregate;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Infrastructure.Data
{
    public class JacketContext : DbContext
    {
        public JacketContext(DbContextOptions<JacketContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Disposition> Dispositions { get; set; }
        public DbSet<Jacket> Jackets { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Plaintiff> Plaintiffs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasSequence<int>("JacketNumbers").StartsAt(1).IncrementsBy(1);

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
