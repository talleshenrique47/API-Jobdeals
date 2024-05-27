namespace JobDealsAPI.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; }

        public int ProfileId { get; set; } // Chave estrangeira para o perfil
        public ProfileModel? Profile { get; set; } // Referência ao perfil
    }
}
