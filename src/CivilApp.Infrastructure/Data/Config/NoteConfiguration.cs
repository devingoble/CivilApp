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
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.Property(b => b.Text).HasMaxLength(500);
            builder.Property(b => b.IsFlaggedDeputySafety).IsRequired().HasDefaultValue(false);
        }
    }
}
