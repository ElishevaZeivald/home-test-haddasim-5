using DALgrocery.DALmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLgrocery.BLmodel
{
    public class BLproduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal PricePerItem { get; set; }

        public int minQuantity { get; set; }

    }
}
