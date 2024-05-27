namespace JobDealsAPI.Models.Dtos
{
    public class ExperienceDTO
    {        
        public int Id { get; set; }
        public string? JobTitle { get; set; }
        public string? Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

