using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProjectTaskKabadiwala.Models
{
    public class StudentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name !!")]
        //[StringLength(25, MinimumLength = 4, ErrorMessage = "Employee Name should be of atleast 4 characters")]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Please Enter Your Mobile No !!")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Mobile Number.")]
        public string ContactNo { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please Enter Your Address !!")]
        public string Address { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Please Enter Your E-Mail !!")]
        public string Email { get; set; }
    }
}
