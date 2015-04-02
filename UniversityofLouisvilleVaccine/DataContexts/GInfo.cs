using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.DataContexts
{
    public class GInfoDBContext : DbContext
    {

        public GInfoDBContext()
            :base("DefaultConnection")
        {

        }
        public DbSet<GInfo> GInfos { get; set; }

    }
}