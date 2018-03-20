using Autofac;
using cBaseQms.Core.Repositry.Infrastructure;
using cBaseQms.Core.Repositry.Repositories;

namespace cBasQms.Core.ResolveDependency
{
    public class RepositryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            //builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerLifetimeScope();
            builder.RegisterType<TestMasterRepository>().As<ITestMasterRepository>().InstancePerLifetimeScope();
           // builder.RegisterType<TestRepositry>().As<ITestRepository>().InstancePerLifetimeScope();
           //// builder.RegisterType<TestExpressionRepository>().As<ITestExpressionRepository>().InstancePerLifetimeScope();
           // builder.RegisterType<PartMasterRepositry>().As<IPartMasterRepositry>().InstancePerLifetimeScope();
           // builder.RegisterType<LocationMasterRepositry>().As<ILocationMasterRepositry>().InstancePerLifetimeScope();
           // builder.RegisterType<TestMasterMappingRepositry>().As<ITestMasterMappingRepositry>().InstancePerLifetimeScope();
            //builder.RegisterType<ComponentRepositry>().As<IComponentRepositry>().InstancePerLifetimeScope();
            //builder.RegisterType<AppParameterRepository>().As<IAppParameterRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<EquationRepositry>().As<IEquationRepositry>().InstancePerLifetimeScope();
            //builder.RegisterType<TestInputFieldsRepositry>().As<ITestInputFieldsRepositry>().InstancePerLifetimeScope();
            //builder.RegisterType<VWLocationAttributesRepository>().As<IVWLocationAttributesRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<PartAttributesRepository>().As<IPartAttributesRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<TestCalculatedFieldsRepository>().As<ITestCalculatedFieldsRepository>().InstancePerLifetimeScope();
        }
    }
}
