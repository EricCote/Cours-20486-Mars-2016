
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PremierMvc.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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


        async public Task<ActionResult> Test(int id)
        {
            HttpClient http = new HttpClient();
            HttpResponseMessage msg = await http.GetAsync("http://localhost:50513/api/products/" + id.ToString());
            string data = await msg.Content.ReadAsStringAsync();
            Product p = JsonConvert.DeserializeObject<Product>(data);

            if (p == null)
            {
                  return HttpNotFound();
            }

            return View(p);
        }

    }


}