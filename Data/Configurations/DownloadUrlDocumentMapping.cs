using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class DownloadUrlDocumentMapping : IEntityTypeConfiguration<DownloadUrlDocument>
    {
        public void Configure(EntityTypeBuilder<DownloadUrlDocument> builder)
        {
            builder.HasKey(x => x.IdCode);
        }
    }
}