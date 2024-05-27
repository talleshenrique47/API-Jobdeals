using JobDealsAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Data.Map
{
    public class HardSkillMap : IEntityTypeConfiguration<HardSkillModel>
    {
        public void Configure(EntityTypeBuilder<HardSkillModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.HardSkillName).IsRequired().HasMaxLength(100);

            builder.HasOne(p => p.Profile)
                .WithMany(pr => pr.HardSkills)
                .HasForeignKey(p => p.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
