using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.DataContexts
{
    public class ApptDBContext:DbContext
    {
        public ApptDBContext()
            : base("DefaultConnection")
        {

        }
                public DbSet<Appointment> Appointments { get; set; }
    }
}