using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using JobDealsAPI.Models;

namespace JobDealsAPI.Data.Map
{
    public class AboutMap : IEntityTypeConfiguration<AboutModel>
    {
        public void Configure(EntityTypeBuilder<AboutModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(10000);

            builder.HasOne(a => a.Profile)
               .WithOne(p => p.About)
               .HasForeignKey<AboutModel>(a => a.ProfileId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
