using System.ComponentModel.DataAnnotations;

namespace JobDealsAPI.Models.Dtos
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
