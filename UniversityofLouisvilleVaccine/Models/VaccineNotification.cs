using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace UniversityofLouisvilleVaccine.Models
{
    public class VaccineNotification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationID { get; set; }
        
        public string vaccineID { get; set; }

        public string vaccineName { get; set; }
        
        public string lotNumber { get; set; }
        
        public int numofDoses { get; set; }

        public int warning { get; set; }
               
        public bool notificationchecked { get; set; }

    }


}