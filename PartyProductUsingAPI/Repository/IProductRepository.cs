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
        Task<int> ProductAddAsync(Product productModel);
        Task EditProductAsync(int id, Product product);
        Task DeleteProductAsync(int id);
    }
}
