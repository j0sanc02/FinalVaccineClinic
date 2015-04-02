using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityofLouisvilleVaccine.Models
{
    public class Vendor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string vendorName { get; set; }

        [Display(Name = "Telephone")]
        public string vendorPhone { get; set; }
              
        [Display(Name = "Fax Number")]
        public string vendorFax { get; set; }
                
        [Display(Name = "Email")]
        public string vendorEmail { get; set; }

        [Display(Name = "Website")]
        public string vendorWebsite { get; set; }
                
        [Display(Name = "Address 1")]
        public string vendorAddress1 { get; set; }

        [Display(Name = "Address 2")]
        public string vendorAddress2 { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "State")]
        public string state { get; set; }

        [Display(Name = "ZIP")]
        public string zip { get; set; }

        [Display(Name = "Vaccines")]
        [DataType(DataType.MultilineText)]
        public string vaccines { get; set; }

    }

}