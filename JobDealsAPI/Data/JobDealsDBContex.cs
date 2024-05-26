using JobDealsAPI.Data.Map;
using JobDealsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Data
{
    public class JobDealsDBContex : DbContext
    {
        public JobDealsDBContex(DbContextOptions<JobDealsDBContex> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());

            modelBuilder.Entity<UserModel>()
                .HasIndex(u => u.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
