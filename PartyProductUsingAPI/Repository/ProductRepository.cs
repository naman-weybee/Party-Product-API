using Microsoft.EntityFrameworkCore;
using PartyProductUsingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProductUsingAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PartyProductMVCContext _context;

        public ProductRepository(PartyProductMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _context.Products
                .Select(product => new Product()
                {
                    Id = product.Id,
                    ProductName = product.ProductName
                }).ToListAsync();
        }

        public async Task<int> ProductAddAsync(Product productModel)
        {
            var newProduct = new Product()
            {
                ProductName = productModel.ProductName
            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return newProduct.Id;
        }

        public async Task EditProductAsync(int id, Product product)
        {
            var updateProduct = new Product()
            {
                Id = id,
                ProductName = product.ProductName
            };

            _context.Products.Update(updateProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = new Product() { Id = id };

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
