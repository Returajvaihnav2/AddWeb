using System.ComponentModel.DataAnnotations;

namespace Api.School.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email ID")]
        public string EmailID { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}

