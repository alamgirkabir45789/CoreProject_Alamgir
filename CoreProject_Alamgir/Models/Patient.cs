using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreProject_Alamgir.Attirbutes.ValidationAttributes;
using CoreProject_Alamgir.CustomValidation;

namespace CoreProject_Alamgir.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
       
        [MaxLength(12, ErrorMessage = "Maximum 12 characters only")]
        public string PatientName { get; set; }

       [Required]
        public string Address { get; set; }

        [Required]
        public string ContactNo { get; set; }

    
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

       [Required]
        public String Department { get; set; }

       

        public DateTime AppointmentDate { get; set; }
    }
}
