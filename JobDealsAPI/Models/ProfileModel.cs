using JobDealsAPI.Enums;
using JobDealsAPI.Models.Dtos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace JobDealsAPI.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public string? PhotoPath { get; set; } // Adicionando propriedade para o caminho da foto de perfil
        public string? UserName { get; set; }
        public string? Title { get; set; }
        public StatusDescription StatusDescription{ get; set; } 
        public string? PhoneNumber { get; set; }
        public string? UserEmail { get; set; }
        public string? Github {  get; set; }

        public int UserId { get; set; }       
        public UserModel? User { get; set; } // Referência ao usuário
        public AboutModel? About { get; internal set; }
        public List<ExperienceModel>? Experiences { get; set; }
        public List<ProjectModel>? Projects { get; set; }
        public List<CertificationModel>? Certifications { get; set; }
        public List<TechnologyModel>? Technologies { get; internal set; }
        public List<LanguageModel>? Languages { get; internal set; }
        public List<HardSkillModel>? HardSkills { get; internal set; }
        public List<SoftSkillModel>? SoftSkills { get; internal set; }
        public List<AcademicFormationModel>? AcademicFormations { get; internal set; }
    }
}
