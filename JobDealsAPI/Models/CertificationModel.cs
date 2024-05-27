namespace JobDealsAPI.Models
{
    public class CertificationModel
    {
        public int Id { get; set; }
        public string? CertificationName { get; set; }
        public DateTime ObtainedDate { get; set; }
        public string? Institution { get; set; }

        public int ProfileId { get; set; } // Chave estrangeira para o perfil
        public ProfileModel? Profile { get; set; } // Referência ao perfil
    }
}
