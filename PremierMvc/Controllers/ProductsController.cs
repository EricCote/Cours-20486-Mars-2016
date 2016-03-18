using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PremierMvc.Models;
using PremierMvc.Filters;

namespace PremierMvc.Controllers
{

    public class ProductsController : Controller
    {
        private AWContext db = new AWContext();

        // GET: Products      
        public ActionResult Index()
        {
        
            var Categories = (from cat in db.ProductCategories
                              where cat.CategoryID <= 4
                              orderby cat.Name
                              select new { cat.Name }).ToList();

            ViewBag.CategoryID = new SelectList(Categories, "Name", "Name", "Bikes");
   
            return View("index", null);



        }


        public PartialViewResult SubCat(string id) {
            var subCategories = (from cat in db.ProductCategories
                                 where cat.CategoryID > 4 && cat.ParentCategory.Name == id
                                 orderby cat.Name
                                 select new { cat.Name }).ToList();

            var addItem = new { Name = "Tous" };
            subCategories.Insert(0, addItem);


            ViewBag.SubCategoryID = new SelectList(subCategories, "Name", "Name", "Tous");
            return PartialView();
        }


        [Route("Products/Grid/{category}/{subCategory?}", Name = "productGrid2")]
        [Route("Produits/Grille/{category}/{subCategory?}", Name = "produitGrille")]
        public PartialViewResult Grid(string category, string subCategory) 
        {
            if (subCategory == null) subCategory = "Tous";

            var products = from p in db.Products.Include(p => p.Category).Include(p => p.ProductModel)
                           where (p.Category.Name == subCategory ||
                                 (subCategory == "Tous" && p.Category.ParentCategory.Name == category))
                           select p;

            return PartialView(products.ToList());
        }


        // GET: Products/5
        [Route("Products/{id:int}", Name= "DetailsProducts")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var categories = from cat in db.ProductCategories
                             where cat.CategoryID > 4
                             select cat;

            ViewBag.CategoryID = new SelectList(categories, "CategoryID", "Name");
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,ProductNumber,Color,StandardCost,ListPrice,Size,Weight,CategoryID,ProductModelID,SellStartDate,SellEndDate,DiscontinuedDate,ThumbNailPhoto,ThumbnailPhotoFileName,rowguid,ModifiedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var categories = from cat in db.ProductCategories
                             where cat.CategoryID > 4
                             select cat;

            ViewBag.CategoryID = new SelectList(categories, "CategoryID", "Name", product.CategoryID);
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name", product.ProductModelID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var categories = from cat in db.ProductCategories
                             where cat.CategoryID > 4
                             select cat;

            ViewBag.CategoryID = new SelectList(categories, "CategoryID", "Name", product.CategoryID);
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name", product.ProductModelID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,ProductNumber,Color,StandardCost,ListPrice,Size,Weight,CategoryID,ProductModelID,SellStartDate,SellEndDate,DiscontinuedDate,ThumbNailPhoto,ThumbnailPhotoFileName,rowguid,ModifiedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var categories = from cat in db.ProductCategories
                             where cat.CategoryID > 4
                             select cat;

            ViewBag.CategoryID = new SelectList(categories, "CategoryID", "Name",product.CategoryID);
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name", product.ProductModelID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [HandleError(View = "ErrorDelete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
