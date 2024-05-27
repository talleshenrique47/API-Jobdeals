using JobDealsAPI.Enums;

namespace JobDealsAPI.Models.Dtos
{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public string? PhotoPath { get; set; }
        public string? UserName { get; set; }
        public string? Title { get; set; }
        public StatusDescription StatusDescription { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserEmail { get; set; }
        public string? Github { get; set; }
        public AboutDTO? About { get; set; }
        public List<ExperienceDTO>? Experiences { get; set; }
        public List<ProjectDTO>? Projects { get; internal set; }
        public List<CertificationDTO>? Certifications { get; internal set; }
        public List<TechnologyDTO>? Technologies { get; internal set; }
        public List<LanguageDTO>? Languages { get; internal set;}
        public List<HardSkillDTO>? HardSkills { get; internal set; }
        public List<SoftSkillDTO>? SoftSkills { get; internal set; }
        public List<AcademicFormationDTO>? AcademicFormations { get; internal set; }

    }
}
