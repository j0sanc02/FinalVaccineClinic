using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.DataContexts
{
    public class AppointmentLookupDBContext : DbContext
    {
        public AppointmentLookupDBContext():base("DefaultConnection")
        {

        }
        DbSet<Appointment> ApptLookup { get; set; }
    }
}