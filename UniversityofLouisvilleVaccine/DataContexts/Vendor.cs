using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.DataContexts
{
    public class VendorDBContext : DbContext 
    {

        public VendorDBContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<Vendor> Vendors { get; set; }

    }

}