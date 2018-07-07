using AutoMapper;
using DowntownRealty;
using Grpc.Core;
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
            var unity = DiContainer.GetContainer();
            var service = unity.Resolve<DowntownRealtyBase>();

            var server = new Server
            {
                Services = { BindService(service) },
                Ports = { new ServerPort("localhost", ServerPort, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Greeter server listening on port " + ServerPort);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
