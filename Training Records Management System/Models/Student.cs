using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICT_TRMS.Models
{
    public class Student
    {

        public int Id { get; set; }

        [Display(Name = "Force Number")]
        public int ForceNumber { get; set; } 

        [Required]
        [Display(Name = "File Number")]
        public String FileNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public String LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }


        [Required]
        [StringLength(15, ErrorMessage = "Telephone number cannot be longer than 15 Digits.")]
        [Display(Name = "Telephone Number")]
        public String TelephoneNumber { get; set; } = string.Empty;

        [Required]
        public String Origin { get; set; } = string.Empty;


        [Required]
        public String Gender { get; set; } = string.Empty;


        public ICollection<StudentMarks> Marks { get; set; } = new List<StudentMarks>();

    }

}
