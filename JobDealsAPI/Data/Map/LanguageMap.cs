using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using JobDealsAPI.Models;

namespace JobDealsAPI.Data.Map
{
    public class LanguageMap : IEntityTypeConfiguration<LanguageModel>
    {
        public void Configure(EntityTypeBuilder<LanguageModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LanguageName).IsRequired().HasMaxLength(100);
            // Adicione outras configurações de propriedade aqui, se necessário

            builder.HasOne(p => p.Profile)
                .WithMany(pr => pr.Languages)
                .HasForeignKey(p => p.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
