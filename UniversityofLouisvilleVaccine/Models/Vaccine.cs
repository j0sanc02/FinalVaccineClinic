using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace UniversityofLouisvilleVaccine.Models
{
    public class Vaccine
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [Required]
        [Display(Name = "Vaccine ID")]
        public string vaccineID { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Display(Name = "Vaccine Name")]
        public string vaccineName { get; set; }
        
        [Required]
        [Display(Name = "Lot Number")]
        public string lotNumber { get; set; }
        
        [Required]
        [Display(Name = "Date Received")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateReceived { get; set; }
        
        [Required]
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime expDate { get; set; }

        [Required]
        [Display(Name = "Refugee Price")]
        public int refugeePrice { get; set; }

        [Required]
        [Display(Name = "Clinic Price")]
        public int clinicPrice { get; set; }

        [Required]
        [Display(Name = "Cost")]
        public int salesPrice { get; set; }
        
        [Required]
        [Display(Name = "CPT")]
        public string CPT { get; set; }

        [Required]
        [Display(Name = "ICD-9 Code")]
        public string ICD9Code { get; set; }

        [Required]
        [Display(Name = "NDC")]
        public string NDC { get; set; }

        [Required]
        [Display(Name = "Lead Time")]
        public int leadTime { get; set; }
      
        [Required]
        [Display(Name = "Quantity")]
        public int numofDoses { get; set; }

        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }

        [Required]
        [Display(Name = "Warning Amount")]
        public int inventoryWarning { get; set; }



    }



}