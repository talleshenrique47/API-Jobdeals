using JobDealsAPI.Enums;

namespace JobDealsAPI.Models.Dtos
{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public string? PhotoPath { get; set; }
        public string? UserName { get; set; }
        public string? Title { get; set; }
        public StatusDescription StatusDescription { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserEmail { get; set; }
        public string? Github { get; set; }
    }
}
