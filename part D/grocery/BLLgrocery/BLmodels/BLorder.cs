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
        public BLsupplier Supplier { get; set; }

        public List<BLorderItem> Items { get; set; } = new List<BLorderItem>();
        public decimal TotalPrice => Items.Sum(item => item.Product.PricePerItem * item.Quantity);

    }
}
