using System.ComponentModel;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace Models.Account
{
    public class Account
    {
        public int Id { get; set; }
        
        [StringLength(20)]
        public string Name { get; set; }
        
        [StringLength(20)]
        public string Password { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
    }
}