namespace JobDealsAPI.Models
{
    public class AcademicFormationModel
    {
        public int Id { get; set; }
        public string? Institution { get; set; }
        public string? Course { get; set; }
        public DateTime CompletionDate { get; set; }

        public int ProfileId { get; set; } // Chave estrangeira para o perfil
        public ProfileModel? Profile { get; set; } // Referência ao perfil
    }
}
