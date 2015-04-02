using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityofLouisvilleVaccine.Models
{
    public class EmailLookup
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string VacID { get; set; }

        public string VacName { get; set; }

        public string lotn { get; set; }

        public DateTime sent { get; set; }



    }
}