using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject_Alamgir.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }


        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Must Be Filled")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be 3-30 char")]
        public string DepartmentName { get; set; }

 

       
        public virtual ICollection<InternDoctor> InternDoctors { get; set; }
    }
}
