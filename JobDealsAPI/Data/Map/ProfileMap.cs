using JobDealsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobDealsAPI.Data.Map
{
    public class ProfileMap : IEntityTypeConfiguration<ProfileModel>
    {
        public void Configure(EntityTypeBuilder<ProfileModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).HasMaxLength(255);
            builder.Property(x => x.Title).HasMaxLength(1000);
            builder.Property(x => x.StatusDescription).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);
            builder.Property(x => x.UserEmail).HasMaxLength(150);
            builder.Property(x => x.Github).HasMaxLength(255);

            builder.HasOne(p => p.User)           // Um perfil tem um usuário
                   .WithOne(u => u.Profile)      // Um usuário tem um perfil
                   .HasForeignKey<ProfileModel>(p => p.UserId) // Chave estrangeira para UserId em ProfileModel
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.About)
               .WithOne(a => a.Profile)
               .HasForeignKey<AboutModel>(a => a.ProfileId)
               .IsRequired(false);
        }
    }
}