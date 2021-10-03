using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class DistributionMapping : IEntityTypeConfiguration<Distribution>
    {
        public void Configure(EntityTypeBuilder<Distribution> builder)
        {
            builder.HasKey(x => x.IdCode);
        }
    }
}