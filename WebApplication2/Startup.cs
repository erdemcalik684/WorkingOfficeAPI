using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWithWebToken.Domain;
using ApiWithWebToken.Domain.Repository;
using ApiWithWebToken.Domain.Service;
using ApiWithWebToken.Domain.UnitOfWork;
using ApiWithWebToken.Service;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //Veritaban� ba�lant� i�lemi bu �ekilde yap�l�r
        public void ConfigureServices(IServiceCollection services)
        {
            //bir request boyunca 1 kez olu�turur
            //bunu hep kullan�r...
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //hata almamak i�in bu tercih ediliyor.


            services.AddDbContext<ApiWithWebTokenDatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString:DefaultConnectionString"]);
            });
            services.AddControllers();
        }


        //Middleware'lar...
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
