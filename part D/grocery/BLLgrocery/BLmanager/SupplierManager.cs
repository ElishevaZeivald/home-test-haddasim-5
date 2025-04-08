using DALgrocery.DALIrepository;
using DALgrocery.DALmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLgrocery.BLmanager
{
    public class SupplierManager
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierManager(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public Supplier CreateSupplier(string companyName, string phoneNumber, string representativeName)
        {
            var supplier = new Supplier
            {
                CompanyName = companyName,
                PhoneNumber = phoneNumber,
                RepresentativeName = representativeName
            };

            _supplierRepository.Add(supplier);
            return supplier;
        }

        public Supplier GetSupplierById(int id)
        {
            return _supplierRepository.GetById(id);
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _supplierRepository.GetAll();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            _supplierRepository.Update(supplier);
        }

        public void DeleteSupplier(int id)
        {
            _supplierRepository.Delete(id);
        }

    }
}
