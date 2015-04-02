namespace UniversityofLouisvilleVaccine.DataContexts.ApptMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityofLouisvilleVaccine.DataContexts.ApptDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\ApptMigrations";
        }

        protected override void Seed(UniversityofLouisvilleVaccine.DataContexts.ApptDBContext context)
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
