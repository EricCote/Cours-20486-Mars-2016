namespace PremierMvc.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PremierMvc.Models.DAL.MailingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PremierMvc.Models.DAL.MailingContext";
        }

        protected override void Seed(PremierMvc.Models.DAL.MailingContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Personnes.AddOrUpdate(new Personne()
            {
                PersonneID=1,
                Nom = "Eric",
                Courriel = "eric@afiexpertise.com",
                DateNaissance = new DateTime(1971, 01, 13),
                Sexe ="M"
            });
            context.Personnes.AddOrUpdate(new Personne()
            {
                PersonneID=2,
                Nom = "Arnaud",
                Courriel = "arnaud@afiexpertise.com",
                DateNaissance = new DateTime(1979, 02, 21),
                Sexe = "M"
            });
            context.Personnes.AddOrUpdate(new Personne()
            {
                PersonneID=3,
                Nom = "Alain",
                Courriel = "alain@afiexpertise.com",
                DateNaissance = new DateTime(1985, 05, 30),
                Sexe = "M"
            });

   

      


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
