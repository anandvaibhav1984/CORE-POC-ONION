using Autofac;
using cBaseQms.Core.Services.Models;
//using cBaseQMS.Api.Caching;
using cBaseQMS.Api.Validatiors;
using FluentValidation;
using FluentValidation.WebApi;
using System.Web.Http.Validation;

namespace cBaseQms.Core.Api.AutoFacConfiguration
{
    public class AutofacWebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {            
            //builder.RegisterType<TestMasterMappingValidator>().As<IValidator<TestMasterMappingViewModel>>().InstancePerLifetimeScope();
            builder.RegisterType<TestMasterValidator>().As<IValidator<TestMasterViewModel>>().InstancePerLifetimeScope();
           // builder.RegisterType<TestValidator>().As<IValidator<TestsViewModel>>().InstancePerLifetimeScope();
            builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>().InstancePerLifetimeScope();
            builder.RegisterType<FluentValidationModelValidatorProvider>().As<ModelValidatorProvider>().InstancePerLifetimeScope();
            //builder.RegisterType<InMemoryCache>().As<ICacheService>().InstancePerLifetimeScope();

        }
    }
}