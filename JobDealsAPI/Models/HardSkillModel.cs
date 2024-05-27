namespace JobDealsAPI.Models
{
    public class HardSkillModel
    {
        public int Id { get; set; }
        public string? HardSkillName { get; set; }

        public int ProfileId { get; set; } // Chave estrangeira para o perfil
        public ProfileModel? Profile { get; set; } // Referência ao perfil
    }
}
