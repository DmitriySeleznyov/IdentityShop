using InternetShop.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Contracts.Interfaces
{
    public interface IBasketRepository
    {
        IEnumerable<Basket> GetAll();

        Basket GetById(int id);

        void Add(Basket report);

        void Update(Basket reportWithChanges);

        void Delete(int id);
    }
}
