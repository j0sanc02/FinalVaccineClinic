using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.DataContexts
{
    public class GrantsDBContext : DbContext
    {
        
        public GrantsDBContext()
            : base("Default Connection")
        {

        }

        public DbSet<Grants> Grant { get; set; }
        public DbSet<FilePath> FilePaths { get; set; }

    }
}