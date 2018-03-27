using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InternetShop.Models;
using InternetShopIdentity.Models;
using Microsoft.AspNet.Identity;

namespace InternetShopIdentity.Controllers
{
    public class ProductModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductModels
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: ProductModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = db.Products.Find(id);
            if (productModel == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        // GET: ProductModels/Create
        [Authorize(Roles = "seller")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductModels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProduct,Name,Count,Price")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(productModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productModel);
        }

        // GET: ProductModels/Edit/5
        [Authorize(Roles = "seller")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = db.Products.Find(id);
            if (productModel == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        // POST: ProductModels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "seller")]
        public ActionResult Edit([Bind(Include = "IDProduct,Name,Count,Price")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productModel);
        }

        // GET: ProductModels/Delete/5
        [Authorize(Roles = "seller")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = db.Products.Find(id);
            if (productModel == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        // POST: ProductModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "seller")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductModel productModel = db.Products.Find(id);
            db.Products.Remove(productModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //передать в корзину ид пользователя для очистки корзины по его товарам.
        public ActionResult Buy(int id, int count)
        {
            db.Baskets.Add(new BasketModel { Count = count, Products = db.Products.Where(x => x.IDProduct == id).ToList(), Date = DateTime.Now, Users = db.Users.Where(x => x.Id == User.Identity.GetUserId()).ToList() });
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
