using JobDealsAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Data.Map
{
    public class CertificationMap : IEntityTypeConfiguration<CertificationModel>
    {
        public void Configure(EntityTypeBuilder<CertificationModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CertificationName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Institution).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ObtainedDate).IsRequired();

            builder.HasOne(c => c.Profile)
                   .WithMany(p => p.Certifications)
                   .HasForeignKey(c => c.ProfileId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
