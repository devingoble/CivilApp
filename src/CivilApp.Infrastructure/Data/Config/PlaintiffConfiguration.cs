using CivilApp.Core.Entities.JacketAggregate;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp.Infrastructure.Data.Config
{
    public class PlaintiffConfiguration : IEntityTypeConfiguration<Plaintiff>
    {
        public void Configure(EntityTypeBuilder<Plaintiff> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
        }
    }
}
