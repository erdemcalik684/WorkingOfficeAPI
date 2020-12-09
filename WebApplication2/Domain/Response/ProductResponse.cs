using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithWebToken.Domain.Response
{
    public class ProductResponse : BaseResponse
    {
        public Product Product { get; set; }
        //productı ekle...
        private ProductResponse(bool success, string message,Product product) : base(success, message)
        {
            this.Product = product;
        }

        //Başarılı Olursa
        public ProductResponse(Product product) : this(true, string.Empty, product) { }

        //Başarısız Olursa
        public ProductResponse(string message) : this(false, message, null) { }


    }
}
