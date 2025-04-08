using DALgrocery.DALIrepository;
using DALgrocery.DALmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLgrocery.BLmanager
{
    public class ProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product CreateProduct(string name, decimal price, int minQuantity)
        {
            var product = new Product
            {
                Name = name,
                PricePerItem = price,
                minQuantity = minQuantity
            };

            _productRepository.Add(product);
            return product;
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }
    }
}

