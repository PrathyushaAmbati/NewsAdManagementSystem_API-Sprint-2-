using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NewsAdManagementSystem_BAL.Services;
using NewsAdManagementSystem_DAL.Data;
using NewsAdManagementSystem_DAL.Repository;
using NewsAdManagementSystem_DAL.Repository.CustomerDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAdManagementSystem_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ConnectionString>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            services.AddControllers();
            //EmployDetails
            services.AddTransient<IEmployRepository, EmployRepository>();
            services.AddTransient<EmployService, EmployService>();
            //AdvertisementDetails
            services.AddTransient<IAdvertisementRepository, AdvertisementRepository>();
            services.AddTransient<AdvertisementService, AdvertisementService>();
            //CustomerDetails
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<CustomerService, CustomerService>();
            //CustomerAdDetails
            services.AddTransient<ICustomerAdRepository, CustomerAdRepository>();
            services.AddTransient<CustomerAdService, CustomerAdService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
