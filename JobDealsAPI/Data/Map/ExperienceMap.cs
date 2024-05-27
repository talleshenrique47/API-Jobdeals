using JobDealsAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Data.Map
{
    public class ExperienceMap : IEntityTypeConfiguration<ExperienceModel>
    {
        public void Configure(EntityTypeBuilder<ExperienceModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.JobTitle).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Company).IsRequired().HasMaxLength(100);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired(false);

            builder.HasOne(e => e.Profile)
                   .WithMany(p => p.Experiences)
                   .HasForeignKey(e => e.ProfileId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
