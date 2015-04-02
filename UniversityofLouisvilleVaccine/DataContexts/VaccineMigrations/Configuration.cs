namespace UniversityofLouisvilleVaccine.DataContexts.VaccineMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityofLouisvilleVaccine.DataContexts.VaccineDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\VaccineMigrations";
        }

        protected override void Seed(UniversityofLouisvilleVaccine.DataContexts.VaccineDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
