using ECommerceAPI.Entities;
using ECommerceAPI.Entities.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.DataAcces.Repositories
{
    public interface IProductRepository
    {
        Task<(ICollection<ProductInfo> collection, int total)> GetCollectionAsync(string filter, int page, int rows);

        Task<Product> GetItemAsync(string id);

        Task<string> CreateAsync(Product entity);

        Task UpdateAsync(Product entity);

        Task DeleteAsync(string id);
    }
}
