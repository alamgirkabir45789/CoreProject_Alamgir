using CoreProject_Alamgir.Attirbutes.ValidationAttributes;
using CoreProject_Alamgir.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject_Alamgir.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage ="This Field Must Be Fill!!!!")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Enter Minimum 2 or maximum 40 chacacter !!")]
        [Display(Name = "Doctor Name", Description = "Name of the Student")]
        public string Name { get; set; }


        [Required(ErrorMessage = "This Field Must Be Fill!!!!")]
        public string Address { get; set; }


        [Required(ErrorMessage = "This Field Must Be Fill!!!!")]
        [Range(26, 60, ErrorMessage = "Age Must be between 26 to 60")]
        public int Age { get; set; }


        [Required(ErrorMessage = "This Field Must Be Fill!!!!")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "This Field Must Be Fill!!!!")]
        [EmailAddress]
        public string Email { get; set; }

           

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM dd, yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "JoiningDate")]
        public DateTime JoiningDate { get; set; }
       
       
        public string UrlImage { get; set; }

        [NotMapped]
        public IFormFile ImageUrl { get; set; }
    }
}
