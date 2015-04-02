using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityofLouisvilleVaccine.Models
{
    public class FilePath
    {
        public int FilePathId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        public FileType FileType { get; set; }
        public int GrantID { get; set; }
        public virtual Grants Grant { get; set; }
    }
}