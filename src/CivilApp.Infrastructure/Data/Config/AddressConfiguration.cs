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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(b => b.City).HasMaxLength(50);
            builder.Property(b => b.StreetAddress).HasMaxLength(200);
            builder.Property(b => b.Label).HasMaxLength(200);
            builder.Property(b => b.Zip).HasMaxLength(10);
        }
    }
}
