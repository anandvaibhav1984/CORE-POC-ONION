using Autofac;
using cBaseQMS.Areas.cBaseQMS.RestController;
using cBaseQMS.Core.UI.RestSharp.RestClientHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cBaseQMS.Core.UI.RestSharp.ResolveRestDependency
{
    public class ResolveRestClientDependency : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<TestMasterClient>().As<ITestMasterClient>();
            builder.RegisterType<RestClientBase>().As<IRestClientBase>();
            //builder.RegisterType<RestClient>().As<IRestClient>().WithParameter("baseUrl",Constants.ApiUrl);
            //builder.Register((c, p) => new RestClient(Constants.ApiUrl));
           // builder.RegisterType<TestClient>().As<ITestClientService>().InstancePerRequest();

        }
    }
}