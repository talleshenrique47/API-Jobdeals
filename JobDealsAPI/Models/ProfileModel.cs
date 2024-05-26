using JobDealsAPI.Enums;
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
    }
}
