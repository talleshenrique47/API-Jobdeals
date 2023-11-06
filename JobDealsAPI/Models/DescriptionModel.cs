using JobDealsAPI.Enums;

namespace JobDealsAPI.Models
{
    public class DescriptionModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusDescription Status { get; set; }
        public int? UserId { get; set; }
        
        public virtual UserModel? User { get; set; }
    }
}
