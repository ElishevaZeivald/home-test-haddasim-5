using DALgrocery.DALmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALgrocery.DALIrepository
{
    public interface IOrderItemRepository
    {
        void Add(OrderItem orderItem);
        OrderItem GetById(int id);
        List<OrderItem> GetAll();
        void Update(OrderItem orderItem);
        void Delete(int id);
    }
}
