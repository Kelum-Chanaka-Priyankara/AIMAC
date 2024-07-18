using System.ComponentModel.DataAnnotations;

namespace MedicalAssistant_API.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }


    }
}
