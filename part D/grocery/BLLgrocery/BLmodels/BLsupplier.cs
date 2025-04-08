using DALgrocery.DALmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLgrocery.BLmodel
{
    public class BLsupplier
    {
        public int ID { get; set; }
        public BLuser user { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set;}
        public string RepresentativeName { get; set;}

        public List<BLproduct> Products { get; set; } = new List<BLproduct>();
    }
}
