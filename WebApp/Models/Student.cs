using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        public string Rollno { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
