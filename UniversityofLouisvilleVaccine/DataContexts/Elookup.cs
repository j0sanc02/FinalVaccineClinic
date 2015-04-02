using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.DataContexts
{
    public class ElookupDBContext : DbContext
    {
        public ElookupDBContext()
            :base("DefaultConnection")
        {

        }
        public DbSet<Elookup> Elookups { get; set; }

    }
}