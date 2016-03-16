using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PremierMvc.Models.DAL
{
    public class MailingContext : DbContext
    {
        public MailingContext() : base("Mailing")
        {
        }


        public DbSet<Personne> Personnes { get; set; }
    }
}