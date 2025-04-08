using DALgrocery.DALmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLgrocery.BLmodel
{
    public class BLorder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
