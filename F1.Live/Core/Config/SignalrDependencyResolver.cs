using Castle.MicroKernel;
using F1.Live.Core.Extensions;
using SignalR;
using SignalR.Hubs;

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
            if(serviceType.CanBeCastTo<Hub>())
                return _kernel.Resolve(serviceType);

            return base.GetService(serviceType);
        }
    }
}