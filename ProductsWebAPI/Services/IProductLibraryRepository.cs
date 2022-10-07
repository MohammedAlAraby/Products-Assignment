using ProductsWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebAPI.Services
{
    public interface IProductLibraryRepository
    {
        IEnumerable<Category> GetCategories();

        IEnumerable<Product> GetProducts();

        Product GetProduct(Guid productId);

        IEnumerable<Product> GetProductsByCategory(Guid categoryId);

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        bool Save();
    }
}
