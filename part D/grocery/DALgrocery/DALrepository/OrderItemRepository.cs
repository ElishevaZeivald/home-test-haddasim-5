using DALgrocery.DALIrepository;
using DALgrocery.DALmodels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALgrocery.DALrepository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DbContext _context;

        public OrderItemRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
        }

        public OrderItem GetById(int id)
        {
            return _context.OrderItems.FirstOrDefault(o => o.Id == id);
        }

        public List<OrderItem> GetAll()
        {
            return _context.OrderItems.ToList();
        }

        public void Update(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var orderItem = _context.OrderItems.FirstOrDefault(o => o.Id == id);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
                _context.SaveChanges();
            }
        }
    }
}
