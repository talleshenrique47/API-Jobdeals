namespace JobDealsAPI.Models.Dtos
{
    public class CertificationDTO
    {
        public int Id { get; set; }
        public string? CertificationName { get; set; }
        public DateTime ObtainedDate { get; set; }
        public string? Institution { get; set; }
    }
}
