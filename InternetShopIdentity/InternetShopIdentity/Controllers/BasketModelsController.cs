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
using Microsoft.AspNet.Identity.EntityFramework;

namespace InternetShopIdentity.Controllers
{
    public class BasketModelsController : MainController
    {
        public ActionResult Index()
        {
            return View(db.Baskets.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasketModel basketModel = db.Baskets.Find(id);
            if (basketModel == null)
            {
                return HttpNotFound();
            }
            return View(basketModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBasket,Date,Count")] BasketModel basketModel)
        {
            if (ModelState.IsValid)
            {
                db.Baskets.Add(basketModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(basketModel);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasketModel basketModel = db.Baskets.Find(id);
            if (basketModel == null)
            {
                return HttpNotFound();
            }
            return View(basketModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBasket,Date,Count")] BasketModel basketModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basketModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(basketModel);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasketModel basketModel = db.Baskets.Find(id);
            if (basketModel == null)
            {
                return HttpNotFound();
            }
            return View(basketModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BasketModel basketModel = db.Baskets.Find(id);
            db.Baskets.Remove(basketModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Ordering()
        {
            var userId = User.Identity.GetUserId();
            foreach (var basket in db.Baskets.Where(
               x => x.Users.Contains(db.Users.FirstOrDefault(t => t.Id == userId))))
            {
                db.Orders.Add(new OrderModel
                {
                    Count = basket.Count,
                    Products = basket.Products,
                    Status = "Готовится к выполнению",
                    Date = DateTime.UtcNow,
                    Users = new List<ApplicationUser>(),
                    Address = "Nova Poch"
                });
              
                db.Baskets.Remove(basket);
            }
            db.SaveChanges();
              return RedirectToAction("Index","ProductModels");
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
 