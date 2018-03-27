using InternetShop.Contracts.DataContracts;
using InternetShop.Contracts.Interfaces;
using InternetShop.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.DAL.Repositories
{
    public class BasketRepository:IBasketRepository
    {
        internal InternetShopContext db;
        internal DbSet<Basket> dbSet;

        public BasketRepository(InternetShopContext db)
        {
            this.db = db;
            this.dbSet = db.Set<Basket>();
        }
        public virtual IEnumerable<Basket> GetAll()
        {
            var result = dbSet.ToList();
            return result;
        }
        public virtual Basket GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(Basket entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            Basket entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(Basket entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(Basket entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
