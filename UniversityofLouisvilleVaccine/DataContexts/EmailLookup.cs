using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.DataContexts
{
    public class EmailLookupDBContext: DbContext
    {
        public EmailLookupDBContext ()
            : base ("DefaultConnection")
        {

        }

        public DbSet<EmailLookup> emaillookups { get; set; }
    }
}