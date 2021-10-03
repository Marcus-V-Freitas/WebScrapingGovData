using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ContactPointMapping : IEntityTypeConfiguration<ContactPoint>
    {
        public void Configure(EntityTypeBuilder<ContactPoint> builder)
        {
            builder.HasKey(x => x.IdCode);
        }
    }
}