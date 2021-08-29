using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using CodiNovaDal;

namespace CodiNovaRepo
{
    public class BalProductRepository : IBalProductRepository
    {
        IDalProductRepository productRepository = null;
        public BalProductRepository()
        {
            productRepository = new ProductSqlRepo();
        }
        public bool DeleteProduct(Product product)
        {
            return productRepository.DeleteProduct(product);
        }

        public IEnumerable<Product> GetProduct()
        {
            return productRepository.GetProduct();
        }

        public Product GetProductById(string id)
        {
            return productRepository.GetProductById(id);
        }       
        public bool Product(Product product)
        {
            return productRepository.Product(product);
        }
    }
}
