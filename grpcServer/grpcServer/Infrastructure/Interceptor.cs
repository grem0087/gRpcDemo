using Google.Apis.Auth.OAuth2;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace grpcServer.Infrastructure
{
    class ServerCallContextInterceptor : Interceptor
    {
        public ServerCallContextInterceptor()
        {

        }
    }
}
