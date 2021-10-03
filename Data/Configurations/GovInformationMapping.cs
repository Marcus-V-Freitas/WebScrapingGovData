using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class GovInformationMapping : IEntityTypeConfiguration<GovInformation>
    {
        public void Configure(EntityTypeBuilder<GovInformation> builder)
        {
            builder.HasKey(x => x.IdCode);
        }
    }
}