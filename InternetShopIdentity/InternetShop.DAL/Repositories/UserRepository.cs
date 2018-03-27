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
    public class UserRepository:IUserRepository
    {
        internal ApplicationDbContext db;
        internal DbSet<User> dbSet;

        public UserRepository(ApplicationDbContext db)
        {
            this.db = db;
            this.dbSet = db.Set<User>();
        }
        public virtual IEnumerable<User> GetAll()
        {
            var result = dbSet.ToList();
            return result;
        }
        public virtual User GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(User entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            User entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(User entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(User entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
