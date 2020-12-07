using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithWebToken.Domain.Repository
{
    public class BaseRepository
    {
        protected readonly ApiWithWebTokenDatabaseContext _context;
        public BaseRepository (ApiWithWebTokenDatabaseContext context)
        {
            _context = context;
        }
    }
}
