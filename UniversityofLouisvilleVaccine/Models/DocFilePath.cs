using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityofLouisvilleVaccine.Models
{
    public class DocFilePath
    {
        [Key]
        public int FilePathId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        public FileType FileType { get; set; }
        public int GrantDocID { get; set; }
        public virtual GrantDocs Grant { get; set; }
    }
}