using Autofac;
using Autofac.Extensions.DependencyInjection;
using cBaseQms.Core.Api.AutoFacConfiguration;
using cBaseQms.Core.Api.Extensions;
using cBaseQms.Core.Api.Filters;
using cBaseQms.Core.Api.Middleware;
using cBaseQms.Core.Repositry;
using cBaseQms.Core.Repositry.Repositories;
using cBaseQms.Core.Services.Services;
using cBasQms.Core.ResolveDependency;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace cBaseQms.Core.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    var connectionString = Configuration.GetConnectionString("CbaseQMSDatabase");
        //    services.AddDbContext<cBaseDevEntities>(options => options.UseSqlServer(connectionString));
        //    services.AddMvc(options =>
        //    {
        //        //options.Filters.Add(new AddHeaderAttribute("GlobalAddHeader",
        //        //    "Result filter added to MvcOptions.Filters")); // an instance
        //        //options.Filters.Add(typeof(SampleActionFilter)); // by type
        //        options.Filters.Add(new ValidateModelStateFilter()); // an instance
        //    });
        //    services.AddScoped<ITestMasterRepository, TestMasterRepository>();
        //    services.AddTransient<ITestMasterService, TestMasterService>();
        //}
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("CbaseQMSDatabase");
            services.AddDbContext<cBaseDevEntities>(options => options.UseSqlServer(connectionString));


            services.AddMvc(options =>
            {
                //options.Filters.Add(new AddHeaderAttribute("GlobalAddHeader",
                //    "Result filter added to MvcOptions.Filters")); // an instance
                //options.Filters.Add(typeof(SampleActionFilter)); // by type
                options.Filters.Add(new ValidateModelStateFilter()); // an instance
            });
            //services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AutofacWebModule>());
            // Add controllers as services so they'll be resolved.
            services.AddMvc().AddControllersAsServices();
            var builder = new ContainerBuilder();
            // When you do service population, it will include your controller
            // types automatically.
            builder.Populate(services);           
            //services.AddScoped<ITestMasterRepository, TestMasterRepository>();
            // builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new AutofacWebModule());
            builder.RegisterModule(new RepositryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new AutoMapperModule());
            // If you want to set up a controller for, say, property injection
            // you can override the controller registration after populating services.
            builder.RegisterType<Controller>().PropertiesAutowired();
            this.ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
        }
#warning this can be called to registor services directly into autofac
        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices
        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    builder.RegisterModule(new AutofacWebModule());
        //    builder.RegisterModule(new RepositryModule());
        //    builder.RegisterModule(new ServiceModule());
        //    builder.RegisterModule(new AutoMapperModule());
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new JsonExceptionMiddleware().Invoke
            });

            app.UseCors(builder => builder.AllowAnyOrigin());
            //app.UseJsonExceptionMiddleware();
            app.UseMessageHandlerMiddleWare();           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=values}/{action=Index}/{id?}");
            });   //Middleware
        }
    }
}
