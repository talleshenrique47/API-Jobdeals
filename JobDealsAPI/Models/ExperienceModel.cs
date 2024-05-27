namespace JobDealsAPI.Models
{
    public class ExperienceModel
    {
        public int Id { get; set; }
        public string? JobTitle { get; set; }
        public string? Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int ProfileId { get; set; } // Chave estrangeira para o perfil
        public ProfileModel? Profile { get; set; } // Referência ao perfil
    }
}
