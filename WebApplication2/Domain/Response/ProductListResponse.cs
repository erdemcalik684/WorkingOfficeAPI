using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithWebToken.Domain.Response
{
    public class ProductListResponse : BaseResponse
    { 
        public IEnumerable<Product> productList { get; set; }
        private ProductListResponse(bool success, string message, IEnumerable<Product> productList) : base(success, message)
        {
            this.productList = productList;
        }

        //Başarılı Olursa
        public ProductListResponse(IEnumerable<Product> productList) : this(true, string.Empty, productList) { }
        
        
        //Başarısız Olursa
        public ProductListResponse(string message) : this(false, message,null) { }


    }
}
