using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using static DowntownRealty.DowntownRealty;

namespace gRpcClient.Infrastructure
{
    public static class DiContainer
    {
        public static UnityContainer GetContainer()
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new MapperProfile());
            //});

            var _container = new UnityContainer();
            //_container.RegisterInstance<IMapper>("Mapper", config.CreateMapper());
            //_container.RegisterInstance<IMapper>(config.CreateMapper());
            //_container.RegisterType<IRealtyRepository, RealtyRepository>();
            _container.RegisterType<DowntownRealtyClient, RealtyServiceClientImpl>();
            return _container;
        }
    }
}
