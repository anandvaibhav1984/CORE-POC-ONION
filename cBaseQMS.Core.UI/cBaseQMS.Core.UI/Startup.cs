using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using cBaseQms.Core.Repositry;
using cBaseQMS.Areas.cBaseQMS.RestController;
using cBaseQMS.Core.DAL.Models;
using cBaseQMS.Core.UI.RestSharp.ResolveRestDependency;
using cBaseQMS.Core.UI.RestSharp.RestClientHelpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cBaseQMS.Core.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //var connectionString = Configuration.GetConnectionString("CbaseQMSDatabase");
            //services.AddDbContext<cBaseDevEntities>(options => options.UseSqlServer(connectionString));

            services.AddMvc().AddControllersAsServices();
            services.AddMvc();
            var builder = new ContainerBuilder();
            // When you do service population, it will include your controller
            // types automatically.
          
            builder.RegisterModule(new ResolveRestClientDependency());           
            // builder.RegisterType<Controller>().PropertiesAutowired();
            services.AddMvc();
            builder.Populate(services);
            var container = builder.Build();
            //Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
        }

        //public void ConfigureServices(IServiceCollection services)
        //{   
        //    //services.AddMvc().AddControllersAsServices();
        //    services.AddScoped<ITestMasterClient, TestMasterClient>();
        //    services.AddScoped<IRestClientBase, RestClientBase>();
        //    //services.AddTransient<ITestMasterClient, TestMasterClient>();
        //    services.AddMvc();
        //}
        //public void ConfigureContainer(ContainerBuilder builder)
        //{  
        //    builder.RegisterModule(new ResolveRestClientDependency());
        //}
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=TestMaster}/{action=Index}/{id?}");
            });
        }
    }
}
