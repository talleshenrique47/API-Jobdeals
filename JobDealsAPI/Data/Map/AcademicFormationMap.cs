using JobDealsAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Data.Map
{
    public class AcademicFormationMap : IEntityTypeConfiguration<AcademicFormationModel>
    {
        public void Configure(EntityTypeBuilder<AcademicFormationModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Institution).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Course).IsRequired().HasMaxLength(200);
            builder.Property(x => x.CompletionDate).IsRequired();

            builder.HasOne(p => p.Profile)
                .WithMany(pr => pr.AcademicFormations)
                .HasForeignKey(p => p.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
