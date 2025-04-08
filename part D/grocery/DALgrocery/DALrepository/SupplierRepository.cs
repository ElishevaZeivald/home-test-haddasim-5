using DALgrocery.DALmodels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALgrocery.DALrepository
{
    public class SupplierRepository
    {
        private readonly DbContext _context;

        public SupplierRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public Supplier GetById(int id)
        {
            return _context.Suppliers.FirstOrDefault(s => s.Id == id);
        }

        public Supplier GetByCompanyName(string companyName)
        {
            return _context.Suppliers.FirstOrDefault(s => s.CompanyName == companyName);
        }

        public List<Supplier> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public void Update(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }

    }
}
