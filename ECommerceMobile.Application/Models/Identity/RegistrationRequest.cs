using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceMobile.Application.Models.Identity
{
    public class RegistrationRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty; 
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime? BirthOfDate { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role {  get; set; } = string.Empty;
    }
}
