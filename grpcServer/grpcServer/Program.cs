
using Grpc.Core;
using Grpc.Core.Logging;
using Microsoft.AspNetCore.Hosting;
using MagicOnion.Server;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;
using MagicOnion.HttpGateway.Swagger;
using Unity;
using static DowntownRealty.DowntownRealty;
using Grpc.HealthCheck;
using grpcServer.Infrastructure;
using MagicOnion;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.Features;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

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
                var server = new Server()
                {
                    Services = { BindService(service) },
                    Ports = { new ServerPort("localhost", ServerPort, ServerCredentials.Insecure), }

                };
                server.Services.Add(Grpc.Health.V1.Health.BindService(new HealthServiceImpl()));
                server.Start();

                Console.WriteLine("Greeter server listening on port " + ServerPort);
                Console.WriteLine("Press any key to stop the server...");

                //var webHost = new WebHostBuilder()
                //.ConfigureServices(services =>
                //{
                //    // Add MagicOnionServiceDefinition for reference from Startup.
                //    var server = new Server()
                //    {
                //        Services = { BindService(service) },
                //        Ports = { new ServerPort("localhost", ServerPort, ServerCredentials.Insecure), }

                //    };
                //    services.Add(new ServiceDescriptor(typeof(MagicOnionServiceDefinition), service));
                //    services.AddSingleton<Server>(server);
                //    services.AddSingleton<IServer, GrpcHostedService>();
                //})
                //.UseStartup<Startup>()
                //.UseUrls("http://localhost:5432")
                //.Build();

                //webHost.Run();
                Console.ReadLine();

                server.ShutdownAsync().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class GrpcHostedService : IServer
    {
        private Server _server;

        public IFeatureCollection Features => new FeatureCollection();

        public GrpcHostedService(Server server)
        {
            _server = server;
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }

        public Task StartAsync<TContext>(IHttpApplication<TContext> application, CancellationToken cancellationToken)
        {
            Console.WriteLine("Start");
            _server.Start();
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stop");
            await _server.ShutdownAsync();
        }
    }

    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            //app.Use(async (context, nxt) =>
            //{
            //    if(context.Request.Path == ...
            //});
        }
    }
}
