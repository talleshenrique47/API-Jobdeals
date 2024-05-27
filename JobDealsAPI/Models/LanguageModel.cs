namespace JobDealsAPI.Models
{
    public class LanguageModel
    {
        public int Id { get; set; }
        public string? LanguageName { get; set; }
        public int ProfileId { get; set; } // Chave estrangeira para o perfil
        public ProfileModel? Profile { get; set; } // Referência ao perfil
    }
}
