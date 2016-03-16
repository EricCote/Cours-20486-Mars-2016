using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PremierMvc.Models.DAL
{
    public class MailingInitializer : DropCreateDatabaseIfModelChanges<MailingContext>
    {
        protected override void Seed(MailingContext context)
        {
            base.Seed(context);

            context.Personnes.Add(new Personne() { Nom = "Eric", Courriel = "eric@afiexpertise.com",
                                                    DateNaissance = new DateTime(1971, 01, 13) });
            context.Personnes.Add(new Personne() { Nom = "Arnaud", Courriel = "arnaud@afiexpertise.com",
                                                    DateNaissance = new DateTime(1979, 02, 21) });
            context.Personnes.Add(new Personne() { Nom = "Alain", Courriel = "Alain@afiexpertise.com",
                                                    DateNaissance = new DateTime(1985, 05, 30) });

            context.SaveChanges();

        }

    }
}