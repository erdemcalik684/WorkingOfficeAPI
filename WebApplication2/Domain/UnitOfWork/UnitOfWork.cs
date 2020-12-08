using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithWebToken.Domain.UnitOfWork
{
  
    //NOT UNİTOFWORK KULLANIMI NASIL YAPILIR ? 
    public class UnitOfWork : IUnitOfWork
    {
        //1) vt işlemi yapacağım için context sınıfını elde etmemiz gerekiyor.

        //2) dbcontexte heryerden erişebilmemin sebebi,startup üzerinde services.adddbcontext tanımlamamızdır.


        //3) //NOT = AWAIT NE İŞE YARAR.
        //AWAİT İN BULUNDUĞU YERDEKİ METOTDAN SORGU GELENE KADAR BEKLE,GEÇME.
        //SORGU GELDİKTEN SONRA GEÇİŞ YAP DEMEKTİR AWAİT...
        private readonly ApiWithWebTokenDatabaseContext _context;
        public UnitOfWork(ApiWithWebTokenDatabaseContext context)
        {
            _context = context;
        }


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
