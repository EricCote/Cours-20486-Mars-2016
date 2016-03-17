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
            return Filtre("Bikes","Tous");
        }

        public ActionResult Filtre(string category,string subCat)
        {
            var Categories = (from cat in db.ProductCategories
                                 where cat.CategoryID <= 4
                                 orderby cat.Name
                                 select new { cat.Name }).ToList();

            var subCategories = (from cat in db.ProductCategories
                              where cat.CategoryID > 4 && cat.ParentCategory.Name==category
                              orderby cat.Name
                              select new { cat.Name }).ToList();

            var addItem = new { Name = "Tous" };
            subCategories.Insert(0,addItem);

            ViewBag.CategoryID = new SelectList(Categories, "Name", "Name", category);
            ViewBag.SubCategoryID = new SelectList(subCategories, "Name", "Name", subCat);

            var products = from p in db.Products.Include(p => p.Category).Include(p => p.ProductModel)
                           where (p.Category.Name==subCat || 
                                 (subCat=="Tous" && p.Category.ParentCategory.Name==category  ))
                           select p;
            return View("index",products.ToList());
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

        //id est la sous-catégorie
        public PartialViewResult Grid(string id, string category) 
        {
            var products = from p in db.Products.Include(p => p.Category).Include(p => p.ProductModel)
                           where (p.Category.Name == id ||
                                 (id == "Tous" && p.Category.ParentCategory.Name == category))
                           select p;

            return PartialView(products.ToList());
        }


        // GET: Products/Details/5
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
