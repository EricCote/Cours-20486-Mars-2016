using PremierMvc.Models;
using PremierMvc.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PremierMvc.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            Personne p = new Personne() {   Nom = "Test",
                                            Courriel = "test@test.com",
                                            DateNaissance = new DateTime(1980, 01, 13)
            };

            return View(p);
        }

        // POST: Mail
        [HttpPost()]
        public ActionResult Index(Personne p)
        {
            MailingContext db = new MailingContext();
            db.Personnes.Add(p);
            db.SaveChanges();
            return View("merci", p);
        }

        public ActionResult Lister()
        {
            MailingContext db = new MailingContext();
            return View(db.Personnes.ToList());

            ////Call the Repository
            //MailingRepository reader = new MailingRepository();
            //return View(reader.GetPersonnes());
        }


        public ActionResult Delete(int id)
        {
            MailingContext db = new MailingContext();
            Personne p = (from pers in db.Personnes
                         where pers.PersonneID == id
                         select pers).FirstOrDefault();
            //Linq pseudo sql


            //Personne p2 = db.Personnes.Where(pers => pers.PersonneID == id).
            //                          FirstOrDefault();
            ////linq Orienté Object    

            if (p == null)
            { return new HttpStatusCodeResult(404, "Pas de personne avec ce ID"); }

            return View(p);
        }

        [HttpPost(), ActionName("Delete")  ]
        public ActionResult DeleteConfirm(int id)
        {
            MailingContext db = new MailingContext();
            Personne p = (from pers in db.Personnes
                          where pers.PersonneID == id
                          select pers).FirstOrDefault();

            db.Personnes.Remove(p);
            db.SaveChanges();

            return View("Deleted", id);
        }
    }
}