using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JobDealsAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
