using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApplication.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        [Required(ErrorMessage = "This field is required"), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required"), RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be of 10 digits")]
        public string PhoneNo { get; set; }
        public int? Salary { get; set; }
    }
}
