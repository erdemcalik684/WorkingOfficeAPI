using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithWebToken.Domain.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();

        //task ile geriye birşey dönmeyeceğim demektir.async dan dolayı böyledir
        Task AddProductAsync(Product product);
        Task RemoveProductAsync(int productId);
        
        //update de async yoktur.olamaz.
        void UpdateProduct(Product product);
        Task<Product> FindByIdAsync(int productId);
    }
}
