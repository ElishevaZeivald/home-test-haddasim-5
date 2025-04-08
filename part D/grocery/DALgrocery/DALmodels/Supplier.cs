using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALgrocery.DALmodels
{
    public class Supplier
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string RepresentativeName { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
