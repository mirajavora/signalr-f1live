using Castle.MicroKernel;
using F1.Live.Core.Extensions;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace F1.Live.Core.Config
{
    public class SignalrDependencyResolver : DefaultDependencyResolver
    {
        private readonly IKernel _kernel;

        public SignalrDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }


        public override object GetService(System.Type serviceType)
        {
            //lazy man's DI -> only register and resolve the hubs, the rest use the default resolver
            if(serviceType.CanBeCastTo<Hub>())
                return _kernel.Resolve(serviceType);

            return base.GetService(serviceType);
        }
    }
}