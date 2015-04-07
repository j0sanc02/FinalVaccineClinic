using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.DataContexts
{
    public class GrantDocsDBContext : DbContext
    {

        public GrantDocsDBContext()
            : base ("Default Connection")
        {

        }

        public DbSet<GrantDocs> GrantDoc { get; set; }
        public DbSet<DocFilePath> DocFilePaths { get; set; }

    }
}