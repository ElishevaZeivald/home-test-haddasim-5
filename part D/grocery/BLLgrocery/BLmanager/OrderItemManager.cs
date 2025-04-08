using DALgrocery.DALIrepository;
using DALgrocery.DALmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLgrocery.BLmanager
{
    public class OrderItemManager
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemManager(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public OrderItem CreateOrderItem(int productId, int quantity, decimal price)
        {
            var orderItem = new OrderItem
            {
                ProductId = productId,
                Quantity = quantity,
                Price = price
            };

            _orderItemRepository.Add(orderItem);
            return orderItem;
        }

        public OrderItem GetOrderItemById(int id)
        {
            return _orderItemRepository.GetById(id);
        }

        public List<OrderItem> GetAllOrderItems()
        {
            return _orderItemRepository.GetAll();
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _orderItemRepository.Update(orderItem);
        }

        public void DeleteOrderItem(int id)
        {
            _orderItemRepository.Delete(id);
        }
    }
}
