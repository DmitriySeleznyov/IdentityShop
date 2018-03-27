using InternetShop.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Contracts.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();

        Order GetById(int id);

        void Add(Order report);

        void Update(Order reportWithChanges);

        void Delete(int id);
    }
}
