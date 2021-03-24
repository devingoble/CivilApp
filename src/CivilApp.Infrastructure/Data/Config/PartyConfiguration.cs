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
    public class PartyConfiguration : IEntityTypeConfiguration<Party>
    {
        public void Configure(EntityTypeBuilder<Party> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100);
            builder.Property(b => b.PhoneNumber).HasMaxLength(15);
            builder.Property(b => b.AdditionalNotes).HasMaxLength(2000);
        }
    }
}
