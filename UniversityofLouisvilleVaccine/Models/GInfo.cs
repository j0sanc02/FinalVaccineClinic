using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityofLouisvilleVaccine.Models
{
    public class GInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [Display(Name = "Grant Title")]
        public string grantTitle { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime grantStart { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime grantEnd { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public int grantAmount { get; set; }

        [Required]
        [Display(Name = "Sponsor")]
        public string grantFunder { get; set; }

        [Required]
        [Display(Name = "Collaborator(s)")]
        [DataType(DataType.MultilineText)]
        public string collaborator { get; set; }

        [Required]
        [Display(Name = "Coordinator Name")]
        public string coordName { get; set; }

        [Required]
        [Display(Name = "Deadline")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime deadline { get; set; }

        [Required]
        [Display(Name = "Max Pages")]
        public int maxPages { get; set; }

    }
}