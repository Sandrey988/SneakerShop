using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Sneaker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Sneaker.Context;
using Sneaker.Repositories;
using Sneaker.Repositories.Interfaces;

namespace Sneaker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ModelContext>(options => options.UseSqlServer(connection));
            services.AddMvc();

            services.AddTransient<IRepository<Brand>, BrandRepository>();
            services.AddTransient<IRepository<Category>, CategoryRepository>();
            services.AddTransient<IRepository<Material>, MaterialRepository>();
            services.AddTransient<ISneakerRepository<Models.Sneaker>, SneakerRepository>();
            services.AddTransient<IImageRepository, ImgRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IRepository<Size>, SizeRepository>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            
            app.UseMvc(routes =>
            {

            routes.MapRoute(
                name: "AdminDefault",
                template: "Admin/{controller=Index}/{action=Index}/{id?}");

            routes.MapRoute(
                name : "default",
                template: "{controller=Home}/{action=Index}");

            });
        }
        
    }
}
