using InternetShop.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Contracts.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User GetById(int id);

        void Add(User report);

        void Update(User reportWithChanges);

        void Delete(int id);
    }
}
