using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.DataContexts
{
    public class VaccineUseDBContext : DbContext
    {
        public VaccineUseDBContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<VaccineUse> VaccineUses { get; set; }

    }
}