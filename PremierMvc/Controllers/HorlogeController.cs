
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PremierMvc.Models;

namespace PremierMvc.Controllers
{
    public class HorlogeController : Controller
    {
        // GET: Horloge
        public ActionResult Index()
        {
            Horloge heure = new Horloge() { Heure=DateTime.Now, Pays="Angleterre" };

            TimeZone fh =  TimeZone.CurrentTimeZone;

            ////  ViewBag.FuseauHoraire = fh;
            ViewData["FuseauHoraire"] = fh;

            

            return View(heure);
        }


        public ViewResult Test(Personne p)
        {
            ViewBag.Personne = p;

            return View();
        }

    }


}