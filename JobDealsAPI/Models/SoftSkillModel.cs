namespace JobDealsAPI.Models
{
    public class SoftSkillModel
    {
        public int Id { get; set; }
        public string? SoftSkillName { get; set; }

        public int ProfileId { get; set; } // Chave estrangeira para o perfil
        public ProfileModel? Profile { get; set; } // Referência ao perfil
    }
}
