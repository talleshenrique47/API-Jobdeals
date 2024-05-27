namespace JobDealsAPI.Models.Dtos
{
    public class AcademicFormationDTO
    {
        public int Id { get; set; }
        public string? Institution { get; set; }
        public string? Course { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
