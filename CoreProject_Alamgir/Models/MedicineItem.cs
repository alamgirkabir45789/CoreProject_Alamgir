using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreProject_Alamgir.Attirbutes.ValidationAttributes;

namespace CoreProject_Alamgir.Models
{
    [Table("MedicineItem")]
    public class MedicineItem
    {

        [Key]
        public long ID { get; set; }

        [Required, Display(Name = "Medicine Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [DataType(DataType.Date)]
        [Today(ErrorMessage ="Issue date must be Today")]
        public DateTime EntryDate { get; set; }

        [Required]
        public long Quantity { get; set; }

        [ForeignKey("MedicineCategory")]
        public long MedicineCategoryID { get; set; }


        public virtual MedicineCategory MedicineCategory { get; set; }
    }
}