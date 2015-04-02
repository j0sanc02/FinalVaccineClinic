using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.DataContexts
{

        public class VaccineDBContext : DbContext
        {
            public VaccineDBContext()
                : base("DefaultConnection")
            {

            }
            public DbSet<Vaccine> Vaccines { get; set; }
        }

}