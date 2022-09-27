using PartyProductUsingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyProductUsingAPI.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> ProductAddAsync(Product productModel);
        Task<Product> EditProductAsync(int id, Product product);
        Task<Product> GetProductByIdAsync(int id);
        Task DeleteProductAsync(int id);
    }
}
