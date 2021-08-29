using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace CodiNovaRepo
{
    public interface IBalProductRepository
    {
        bool Product(Product product);
        bool DeleteProduct(Product product);
        IEnumerable<Product> GetProduct();
        Product GetProductById(string id);
        //bool IsProductExists(string Id, string custom);
    }
}
