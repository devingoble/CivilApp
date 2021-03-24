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
    public class DispositionConfiguration : IEntityTypeConfiguration<Disposition>
    {
        public void Configure(EntityTypeBuilder<Disposition> builder)
        {
            builder.Property(b => b.AffidavitTextAdditional).HasMaxLength(500);
            builder.Property(b => b.AffidavitTextNotFound).HasMaxLength(500);
            builder.Property(b => b.AffidavitTextServedAt).HasMaxLength(500);
            builder.Property(b => b.AffidavitTextServedTo).HasMaxLength(500);
            builder.Property(b => b.ContainsNecessaryMailings).IsRequired().HasDefaultValue(false);
            builder.Property(b => b.DispositionAtOffice).IsRequired().HasDefaultValue(false);
            builder.Property(b => b.DispositionMailing).IsRequired().HasDefaultValue(false);
            builder.Property(b => b.DispositionPersonal).IsRequired().HasDefaultValue(false);
            builder.Property(b => b.DispositionPosted).IsRequired().HasDefaultValue(false);
            builder.Property(b => b.DispositionSubstitute).IsRequired().HasDefaultValue(false);
            builder.Property(b => b.IsCorrectedAffidavit).IsRequired().HasDefaultValue(false);
            builder.Property(b => b.ProcessDate);
            builder.Property(b => b.RequiresNotary).IsRequired().HasDefaultValue(false);
            builder.Property(b => b.ReturnedTo).HasMaxLength(50);
            builder.Property(b => b.ServedBy).HasMaxLength(50);
        }
    }
}
