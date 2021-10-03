using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ExtractGovContext : DbContext
    {
        public ExtractGovContext(DbContextOptions<ExtractGovContext> options) : base(options)
        {
        }

        public DbSet<DownloadUrlDocument> DownloadUrlDocuments { get; set; }

        public DbSet<GovInformation> GovInformations { get; set; }

        public DbSet<Root> Roots { get; set; }

        public DbSet<ContactPoint> ContactPoints { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Distribution> Distributions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ExtractGovContext).Assembly);
        }
    }
}