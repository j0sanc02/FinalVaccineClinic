using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityofLouisvilleVaccine.Models
{
    public class Elookup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Vaccine Use ID")]
        public int VaccineUseId { get; set; }

        [Required]
        [Display(Name = "Vaccine ID")]
        public string vaccineID { get; set; }

        [Required]
        [Display(Name = "Lot Number")]
        public string lotNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expiration")]
        public DateTime expdate { get; set; }

        [Required]
        [Display(Name = "Patient ID")]
        public string patientID { get; set; }

        [Display(Name = "Left Arm")]
        public bool LinjectionSite { get; set; }

        [Display(Name = "Right Arm")]
        public bool RinjectionSite { get; set; }

        [Display(Name = "Left - Intradermal")]
        public bool LIntradermal { get; set; }

        [Display(Name = "Right - Intradermal")]
        public bool RIntradermal { get; set; }

        [Display(Name = "Left - Intramuscular")]
        public bool LIntramuscular { get; set; }

        [Display(Name = "Right - Intramuscular")]
        public bool RIntramuscular { get; set; }

        [Display(Name = "Left - Subcutaneous")]
        public bool lsub { get; set; }

        [Display(Name = "Right - Subcutaneous")]
        public bool rsub { get; set; }

        [Display(Name = "Left - Intranasal")]
        public bool lnasal { get; set; }

        [Display(Name = "Right - Intranasal")]
        public bool rnasal { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int quantity { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime VaccineUseDate { get; set; }

    }
}