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
    public class JacketConfiguration : IEntityTypeConfiguration<Jacket>
    {
        public void Configure(EntityTypeBuilder<Jacket> builder)
        {
            builder.Property(b => b.State).HasMaxLength(50);
            builder.Property(b => b.City).HasMaxLength(50);
            builder.Property(b => b.County).HasMaxLength(100);
            builder.Property(b => b.Court).HasMaxLength(100);
            builder.Property(b => b.ReceivedFrom).HasMaxLength(100);
            builder.Property(b => b.CourtCaseNumber).HasMaxLength(50);
            builder.Property(b => b.CSPNumber).HasMaxLength(50);
            builder.Property(b => b.DocumentList).HasMaxLength(1000);
            builder.Property(b => b.DocumentCount).IsRequired().HasDefaultValue(0);
            builder.Property(b => b.AmountRecived).HasPrecision(18, 2).IsRequired().HasDefaultValue(0);
            builder.Property(b => b.CheckNumber).HasMaxLength(20);
            builder.Property(b => b.ReceiptNumber).HasMaxLength(20);
            builder.Property(b => b.RefundDue).HasPrecision(18, 2).IsRequired().HasDefaultValue(0);
            builder.Property(b => b.BalanceDue).HasPrecision(18, 2).IsRequired().HasDefaultValue(0);
            builder.Property(b => b.ShouldEnterIntoLEDS).IsRequired().HasDefaultValue(false);
            builder.Property(b => b.ShouldNotAllowSubstituteService).IsRequired().HasDefaultValue(false);
            builder.Property(b => b.IsRush).IsRequired().HasDefaultValue(false);
        }
    }
}