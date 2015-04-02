using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityofLouisvilleVaccine.Models
{
    public class Grants
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [Display(Name = "File Name")]
        public string fileName { get; set; }
        
        [Required]
        [Display(Name = "Document Type")]
        public string docType { get; set; }

        [Required]
        [Display(Name = "Upload Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime uploadDate { get; set; }
        
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<FilePath> FilePaths { get; set; }

        public object Split(char p)
        {
            throw new NotImplementedException();
        }
    }
}