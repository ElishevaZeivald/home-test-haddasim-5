using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALgrocery.DALmodels
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
