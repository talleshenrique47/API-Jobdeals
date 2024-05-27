namespace JobDealsAPI.Models
{
    public class AboutModel
    {
        public int Id { get; set; }
        public string? Description { get; set; } // Descrição sobre o usuário

        public int ProfileId { get; set; } // Chave estrangeira para o perfil
        public ProfileModel? Profile { get; set; } // Referência ao perfil
    }
}
