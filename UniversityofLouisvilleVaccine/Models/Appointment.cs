using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityofLouisvilleVaccine.Models
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Name")]
        public string title { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd-hh:mm}", ApplyFormatInEditMode = true)]
        public string start { get; set; }


        [Display(Name = "Hour")]
        public double hour { get; set; }


        [Display(Name = "Minute")]
        public double min { get; set; }


        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string end { get; set; }

        public bool allDay { get; set; }
    }

    //public class ApptDBContext : DbContext
    //{
    //    public DbSet<Appointment> Appointments { get; set; }

       
    //}

}