using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithWebToken.Domain.Response
{
    public class BaseResponse
    {
        //Geri Dönen Değerler;

        //Başarılı Olabilir
        public bool Success { get; set; }

        //Başarısız Olabilir
        public string Message { get; set; }

        public BaseResponse(bool success,string message)
        {
            this.Success = success;
            this.Message = message;
        }
    }
}
