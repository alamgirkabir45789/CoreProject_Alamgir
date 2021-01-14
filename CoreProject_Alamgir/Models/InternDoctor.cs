using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject_Alamgir.Models
{
    public class InternDoctor
    {
        [Key]
        public int InternDoctorID { get; set; }
        public int DepartmentID { get; set; }

        [Display(Name = "Doctor Name")]
        [Required(ErrorMessage = "Must Be Filled")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string Name { get; set; }

        [Display(Name = "Permanent Address")]
        [Required(ErrorMessage = "Must Be Filled")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Must Be Filled")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Must Be Filled")]
        public string CellPhone { get; set; }

        public virtual Department Department { get; set; }
    }
}
