using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using JobDealsAPI.Models;

namespace JobDealsAPI.Data.Map
{
    public class TechnologyMap : IEntityTypeConfiguration<TechnologyModel>
    {
        public void Configure(EntityTypeBuilder<TechnologyModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TechnologyName).IsRequired().HasMaxLength(100);
            // Adicione outras configurações de propriedade aqui, se necessário

            builder.HasOne(p => p.Profile)
                .WithMany(pr => pr.Technologies)
                .HasForeignKey(p => p.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
