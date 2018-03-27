using InternetShop.Contracts.DataContracts;
using InternetShop.Contracts.Interfaces;
using InternetShopIdentity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.DAL.Repositories
{
    public class ProductRepository:IProductRepository
    {
        internal ApplicationDbContext db;
        internal DbSet<Product> dbSet;

        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
            this.dbSet = db.Set<Product>();
        }
        public virtual IEnumerable<Product> GetAll()
        {
            var result = dbSet.ToList();
            return result;
        }
        public virtual Product GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(Product entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            Product entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(Product entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(Product entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
