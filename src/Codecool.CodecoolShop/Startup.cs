using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Codecool.CodecoolShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container. //zbedny komentarz do usuniecia, wiemy od czego jest ta metoda
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline. //zbedny komentarz do usuniecia, wiemy od czego jest ta metoda
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Product/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });

            SetupInMemoryDatabases();
        }

        private void SetupInMemoryDatabases()
        {
            IProductDao productDataStore = ProductDaoMemory.GetInstance();
            IProductCategoryDao productCategoryDataStore = ProductCategoryDaoMemory.GetInstance();
            ISupplierDao supplierDataStore = SupplierDaoMemory.GetInstance();

            Supplier amazon = new Supplier{Name = "Amazon", Description = "Digital content and services"};
            supplierDataStore.Add(amazon);
            Supplier apple = new Supplier() {Name = "Apple", Description = "Digital content"};
            supplierDataStore.Add(apple);
            Supplier xiaomi = new Supplier() { Name = "Xiaomi", Description = "Digital content" };
            supplierDataStore.Add(xiaomi);
            Supplier garmin = new Supplier() { Name = "Garmin", Description = "Electronics watches" };
            supplierDataStore.Add(garmin);
            Supplier lenovo = new Supplier{Name = "Lenovo", Description = "Computers"};
            supplierDataStore.Add(lenovo);
            ProductCategory tablet = new ProductCategory {Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            ProductCategory smartphone = new ProductCategory { Name = "Smartphone", Department = "Hardware", Description = "A mobile phone that is smart" };
            ProductCategory smartwatch = new ProductCategory { Name = "Smartwatch", Department = "Luxury goods", Description = "A watch with smart functions" };

            productCategoryDataStore.Add(tablet);
            productCategoryDataStore.Add(smartwatch);
            productCategoryDataStore.Add(smartphone);

            productDataStore.Add(new Product { Name = "Amazon Fire", DefaultPrice = 49.9m, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategory = tablet, Supplier = amazon });
            productDataStore.Add(new Product { Name = "Lenovo IdeaPad Miix 700", DefaultPrice = 479.0m, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategory = tablet, Supplier = lenovo });
            productDataStore.Add(new Product { Name = "Amazon Fire HD 8", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategory = tablet, Supplier = amazon });
            productDataStore.Add(new Product { Name = "iPhone 10", DefaultPrice = 500.9m, Currency = "USD", Description = "Fantasic mobile phone", ProductCategory = smartphone, Supplier = apple });
            productDataStore.Add(new Product { Name = "iPhone 8", DefaultPrice = 500.9m, Currency = "USD", Description = "Good enough", ProductCategory = smartphone, Supplier = apple });
            productDataStore.Add(new Product { Name = "Xiaomi Redmi 2", DefaultPrice = 50.9m, Currency = "USD", Description = "Fantasic smartwatch with good price", ProductCategory = smartphone, Supplier = xiaomi });
            productDataStore.Add(new Product { Name = "Garmin Fenix 5", DefaultPrice = 60.9m, Currency = "USD", Description = "Smartwatch with a lot of functions", ProductCategory = smartwatch, Supplier = garmin });
            productDataStore.Add(new Product { Name = "Xiaomi Mi Band 6", DefaultPrice = 70.9m, Currency = "USD", Description = "The best smartwatch", ProductCategory = smartwatch, Supplier = xiaomi });

        }
    }
}
