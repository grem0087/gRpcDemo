using AutoMapper;
using DowntownRealty;
using Grpc.Core;
using Grpc.HealthCheck;
using grpcServer.Core;
using grpcServer.Infrastructure;
using System;
using Unity;
using static DowntownRealty.DowntownRealty;

namespace grpcServer
{
    class Program
    {
        private static readonly int ServerPort = 2323;

        static void Main(string[] args)
        {
            try
            {

                var unity = DiContainer.GetContainer();
                var service = unity.Resolve<DowntownRealtyBase>();

                var server = new Server
                {
                    Services = { BindService(service) },
                    Ports = { new ServerPort("localhost", ServerPort, ServerCredentials.Insecure) }

                };
                var serviceImpl = new HealthServiceImpl();
                server.Services.Add(Grpc.Health.V1.Health.BindService(serviceImpl));

                server.Start();

                Console.WriteLine("Greeter server listening on port " + ServerPort);
                Console.WriteLine("Press any key to stop the server...");
                Console.ReadLine();

                server.ShutdownAsync().Wait();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
