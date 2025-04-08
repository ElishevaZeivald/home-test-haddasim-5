using DALgrocery.DALmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALgrocery.DALIrepository
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product GetById(int id);
        List<Product> GetAll();
        void Update(Product product);
        void Delete(int id);
    }
}
