using JobDealsAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Data.Map
{
    public class ProjectMap : IEntityTypeConfiguration<ProjectModel>
    {
        public void Configure(EntityTypeBuilder<ProjectModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProjectName).IsRequired().HasMaxLength(100);
            // Adicione outras configurações de propriedade aqui, se necessário

            builder.HasOne(p => p.Profile)
                .WithMany(pr => pr.Projects)
                .HasForeignKey(p => p.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
