using System.ComponentModel.DataAnnotations;

namespace Models.Account
{
    public class AuthorizationModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
    }
}