using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DALgrocery.DALmodels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal PricePerItem { get; set; }


        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
