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
    public class BasketModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BasketModels
        public ActionResult Index()
        {
            return View(db.Baskets.ToList());
        }

        // GET: BasketModels/Details/5
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

        // GET: BasketModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BasketModels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: BasketModels/Edit/5
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

        // POST: BasketModels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: BasketModels/Delete/5
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

        // POST: BasketModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BasketModel basketModel = db.Baskets.Find(id);
            db.Baskets.Remove(basketModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Ordering(ApplicationUser user)
        {
            //IDUser = 1;
            //User.Identity.Name
            for (int i = 0; i < db.Baskets.Where(x => x.Users == db.Users.Where(t => t.Id == User.Identity.GetUserId())).Count(); i++)
            {

                db.Orders.Add(new OrderModel
                {
                    Count = ((db.Baskets.First(x => x.Users == db.Users.Where(t => t.UserName == User.Identity.Name))).Count),
                    Products = ((db.Baskets.First(x => x.Users == db.Users.Where(t => t.UserName == User.Identity.Name))).Products),
                    //Status = "Готовится к выполнению",
                    //Date = DateTime.Now,
                    Users = db.Users.Where(x => x.Id == User.Identity.GetUserId()).ToList(),
                    //Address = db.Users.First(x => x.UserName == User.Identity.Name).Address
                });
                db.Baskets.Remove(db.Baskets.First(x => x.Users == db.Users.Where(t => t.UserName == User.Identity.Name)));
            }
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
