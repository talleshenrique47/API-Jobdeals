using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace JobDealsAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }

        public ProfileModel? Profile { get; set; }
    }
}
