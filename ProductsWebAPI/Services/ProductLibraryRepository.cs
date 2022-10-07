using Microsoft.EntityFrameworkCore;
using ProductsWebAPI.DbContexts;
using ProductsWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebAPI.Services
{
    public class ProductLibraryRepository : IProductLibraryRepository
    {
        private readonly ProductLibraryContext _context;

        public ProductLibraryRepository(ProductLibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList<Category>();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList<Product>();
        }

        public Product GetProduct(Guid productId)
        {
            if (productId == Guid.Empty)
                throw new ArgumentNullException();

            return _context.Products.FirstOrDefault(p => p.ID == productId);
        }

        public IEnumerable<Product> GetProductsByCategory(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
                throw new ArgumentNullException();

            return _context.Products.Where(p => p.CateogryID == categoryId).ToList<Product>();
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException();

            product.ID = Guid.NewGuid();

            _context.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException();
            
            _context.Update(product);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }        
    }
}
