using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;

namespace Data.Configurations
{
    public class RootMapping : IEntityTypeConfiguration<Root>
    {
        public void Configure(EntityTypeBuilder<Root> builder)
        {
            builder.HasKey(x => x.IdCode);

            var splitStringConverter = new ValueConverter<IEnumerable<string>, string>(v => string.Join(";", v), v => v.Split(new[] { ';' }));
            builder.Property(nameof(Root.BureauCode)).HasConversion(splitStringConverter);
            builder.Property(nameof(Root.Keyword)).HasConversion(splitStringConverter);
            builder.Property(nameof(Root.ProgramCode)).HasConversion(splitStringConverter);
            builder.Property(nameof(Root.Screenshots)).HasConversion(splitStringConverter);
            builder.Property(nameof(Root.AppCategories)).HasConversion(splitStringConverter);
            builder.Property(nameof(Root.Industries)).HasConversion(splitStringConverter);
            builder.Property(nameof(Root.Tags)).HasConversion(splitStringConverter);
            builder.Property(nameof(Root.TypeKeywords)).HasConversion(splitStringConverter);
            builder.Property(nameof(Root.Extent)).HasConversion(splitStringConverter);
            builder.Property(nameof(Root.Categories)).HasConversion(splitStringConverter);
            builder.Property(nameof(Root.Languages)).HasConversion(splitStringConverter);
        }
    }
}