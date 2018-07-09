using Grpc.Core;
using gRpcClient.Infrastructure;
using System;
using Unity;
using DowntownRealty;
using static DowntownRealty.DowntownRealty;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace gRpcClient
{
    class Program
    {
        private static readonly int ServerPort = 2323;

        static  void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var unity = DiContainer.GetContainer();
            var service = unity.Resolve<DowntownRealtyClient>();
            var channel = new Channel("localhost", ServerPort, ChannelCredentials.Insecure);
            var client = new DowntownRealtyClient(channel);

            //var result = client.GetRealtyList(new RealtyListRequest() { Type = RealtyType.House });

            using (var call = client.UserExchange())
            {
                var responseReaderTask = Task.Run(async () =>
                {
                    while (await call.ResponseStream.MoveNext())
                    {
                        var note = call.ResponseStream.Current;
                        Console.WriteLine("From server Received: " + note);
                    }
                });

                while (true)
                {
                    Console.Write("Send to server: ");
                    call.RequestStream.WriteAsync( new UserRequest { Message = Console.ReadLine() });
                }
                call.RequestStream.CompleteAsync();
                //await responseReaderTask;
            }

            channel.ShutdownAsync().Wait();
        }
    }
}
