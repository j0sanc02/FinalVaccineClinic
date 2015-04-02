using Microsoft.AspNet.Identity.EntityFramework;
using UniversityofLouisvilleVaccine.Models;

namespace UniversityofLouisvilleVaccine.DataContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<UniversityofLouisvilleVaccine.Models.EditUserViewModel> EditUserViewModels { get; set; }

        public System.Data.Entity.DbSet<UniversityofLouisvilleVaccine.Models.RoleViewModel> RoleViewModels { get; set; }

        public System.Data.Entity.DbSet<UniversityofLouisvilleVaccine.Models.EditRoleViewModel> EditRoleViewModels { get; set; }

        public System.Data.Entity.DbSet<UniversityofLouisvilleVaccine.Models.SelectRoleEditorViewModel> SelectRoleEditorViewModels { get; set; }


    }
}