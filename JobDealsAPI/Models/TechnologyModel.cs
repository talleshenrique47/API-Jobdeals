namespace JobDealsAPI.Models
{
    public class TechnologyModel
    {
        public int Id { get; set; }
        public string? TechnologyName { get; set; }
        public int ProfileId { get; set; } // Chave estrangeira para o perfil
        public ProfileModel? Profile { get; set; } // Referência ao perfil
    }
}
