using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;

namespace CrudApplication.Models
{
    public class Login
    {
        [Key]
        public int UserId { get; set; }

        public string Email { get; set; }

 
        public string Password { get; set; }
    }
}
