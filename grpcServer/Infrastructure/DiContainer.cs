using grpcServer.Core;
using Unity;
using static DowntownRealty.DowntownRealty;

namespace grpcServer.Infrastructure
{
    public static class DiContainer
    {        
        public static UnityContainer GetContainer()
        {
            var _container = new UnityContainer();
            _container.RegisterType<IRealtyRepository, RealtyRepository>();
            _container.RegisterType<DowntownRealtyBase, RealtyServiceImpl>();
            return _container;
        }
    }
}
