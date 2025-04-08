using DALgrocery.DALmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLgrocery.BLmodel
{
    public class BLorderItem
    {
        public int ProductId { get; set; }
        public BLproduct Product { get; set; }

        public int OrderId { get; set; }
        public BLorder Order { get; set; }



        public int Quantity { get; set; }
        public decimal Price => Product?.PricePerItem ?? 0;
        public int MinQuantity => Product?.minQuantity ?? 0;
        public Decimal TotalPrice => Product != null ? Quantity * Product.PricePerItem : 0;
    }
}
