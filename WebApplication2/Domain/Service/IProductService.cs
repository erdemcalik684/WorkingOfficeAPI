using ApiWithWebToken.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithWebToken.Domain.Service
{
    public interface IProductService
    {
        //Repo ile haberleşeceğimizden dolayı VT Ile İlgili İşlemler Olacaktır...
        //Bu service,hem repository ile bağlantılı hemde controller ile bağlantılı...
        //Artık ProductResponse lar dönecek burada
        //repositoryde kaç metot varsa o kadar yazılır.
        Task<ProductListResponse> ListAsync();
        Task<ProductResponse> AddProduct(Product product);
        Task<ProductResponse> RemoveProduct(int productId);
        Task<ProductResponse> UpdateProduct(Product product, int productId);
        Task<ProductResponse> FindByIdAsync(int productId); 

    }
}
