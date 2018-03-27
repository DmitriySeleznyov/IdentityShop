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
    public class OrderRepository:IOrderRepository
    {
        internal InternetShopContext db;
        internal DbSet<Order> dbSet;

        public OrderRepository(InternetShopContext db)
        {
            this.db = db;
            this.dbSet = db.Set<Order>();
        }
        public virtual IEnumerable<Order> GetAll()
        {
            var result = dbSet.ToList();
            return result;
        }
        public virtual Order GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(Order entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            Order entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(Order entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(Order entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
