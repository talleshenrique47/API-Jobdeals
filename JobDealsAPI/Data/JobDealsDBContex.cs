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
        public DbSet<AboutModel> Abouts { get; set; }
        public DbSet<ExperienceModel> Experiences { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<CertificationModel> Certifications { get; set; }
        public DbSet<TechnologyModel> Technologies { get; set; }
        public DbSet<LanguageModel> Languages { get; set; }
        public DbSet<HardSkillModel> HardSkills { get; set; }
        public DbSet<SoftSkillModel> SoftSkills { get; set; }
        public DbSet<AcademicFormationModel> AcademicFormations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());
            modelBuilder.ApplyConfiguration(new AboutMap());
            modelBuilder.ApplyConfiguration(new ExperienceMap());
            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new CertificationMap());
            modelBuilder.ApplyConfiguration(new TechnologyMap());
            modelBuilder.ApplyConfiguration(new LanguageMap());
            modelBuilder.ApplyConfiguration(new HardSkillMap());
            modelBuilder.ApplyConfiguration(new SoftSkillMap());
            modelBuilder.ApplyConfiguration(new AcademicFormationMap());

            modelBuilder.Entity<UserModel>()
                .HasIndex(u => u.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
