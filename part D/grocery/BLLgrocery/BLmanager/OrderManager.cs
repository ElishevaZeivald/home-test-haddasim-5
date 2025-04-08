using DALgrocery.DALmodels;
using DALgrocery.DALrepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLgrocery.BLmanager
{
    public class OrderManager
    {
        private readonly OrderRepository _orderRepository;

        public OrderManager(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order CreateOrder(int supplierId, List<OrderItem> items)
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                Status = "New",
                SupplierId = supplierId,
                Items = items
            };

            _orderRepository.Add(order);
            return order;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order GetOrderById(int orderId)
        {
            return _orderRepository.GetById(orderId);
        }

        public void UpdateOrderStatus(int orderId, string newStatus)
        {
            var order = _orderRepository.GetById(orderId);
            if (order != null)
            {
                order.Status = newStatus;
                _orderRepository.Update(order);
            }
        }
    }
}
