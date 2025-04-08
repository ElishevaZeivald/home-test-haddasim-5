using DALgrocery.DALmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALgrocery.DALIrepository
{
    public interface ISupplierRepository
    {
        void Add(Supplier supplier);
        Supplier GetById(int id);
        Supplier GetByCompanyName(string companyName);
        List<Supplier> GetAll();
        void Update(Supplier supplier);
        void Delete(int id);
    }
}
