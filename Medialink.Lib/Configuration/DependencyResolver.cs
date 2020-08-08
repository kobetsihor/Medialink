using Medialink.Dal.Abstractions;
using Medialink.Dal.Repositories;
using MediaLink.Lib.Abstractions;
using MediaLink.Lib.Services;
using Ninject;
using RestSharp;

namespace MediaLink.Lib.Configuration
{
    public class DependencyResolver
    {
        public static void AddBindings(IKernel kernel)
        {
            kernel.Bind<IOperationRepository>().To<OperationRepository>();
            kernel.Bind<IRestClient>().To<RestClient>();
            kernel.Bind<IMathService>().To<MathService>();
        }
    }
}