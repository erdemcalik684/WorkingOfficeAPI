using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithWebToken.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        //geriye birşey dönmeyeceğim demektir.
        Task CompleteAsync();
    }
}
