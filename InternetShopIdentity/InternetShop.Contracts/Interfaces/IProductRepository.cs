using InternetShop.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Contracts.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product GetById(int id);

        void Add(Product report);

        void Update(Product reportWithChanges);

        void Delete(int id);
    }
}
