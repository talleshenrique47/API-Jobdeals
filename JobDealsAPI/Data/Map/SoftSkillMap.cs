using JobDealsAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Data.Map
{
    public class SoftSkillMap : IEntityTypeConfiguration<SoftSkillModel>
    {
        public void Configure(EntityTypeBuilder<SoftSkillModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SoftSkillName).IsRequired().HasMaxLength(100);

            builder.HasOne(p => p.Profile)
                .WithMany(pr => pr.SoftSkills)
                .HasForeignKey(p => p.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
