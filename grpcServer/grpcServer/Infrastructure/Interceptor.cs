using Grpc.Core;
using Grpc.Core.Interceptors;
using System;
using System.Threading.Tasks;
using DowntownRealty;

namespace grpcServer.Infrastructure
{

    public class ServerCallContextInterceptor : Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            //Entering to server implementation method
            var user = context.RequestHeaders.IndexOf(new Metadata.Entry("user", ""));
            var response = await continuation(request, context).ConfigureAwait(false);
            var logObj = (RealtyListResponse)(object)response;
            Console.WriteLine($"Total count: {logObj.Message.Count}"); 
            //Exiting from server implementation method
            return response;
        }
    }
}

