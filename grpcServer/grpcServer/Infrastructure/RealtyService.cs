using grpcServer.Core;
using DowntownRealty;
using grpcServer.Data;
using AutoMapper;
using System.Linq;
using static DowntownRealty.DowntownRealty;
using System.Threading.Tasks;
using Grpc.Core;
using System;
using Grpc.Core.Logging;
using MagicOnion;
using System.Threading;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.Features;

namespace grpcServer.Infrastructure
{
    
    public class RealtyServiceImpl : DowntownRealtyBase
    {
        IRealtyRepository _realtyRepository;
        IMapper _mapper;

        //todo: use logger
        ILogger logger;
        
        public RealtyServiceImpl(IMapper mapper, IRealtyRepository realtyRepository)
        {
            _realtyRepository = realtyRepository;
            _mapper = mapper;
        }

        public override Task<EmptyResponse> HellowWorld(EmptyRequest request, ServerCallContext context)
        {
            var ss = 0;
            Console.WriteLine("hlw");
            return null;
        }

        public override async Task UserExchange(IAsyncStreamReader<UserRequest> requestStream, IServerStreamWriter<UserResponse> responseStream, ServerCallContext context)
        { 
            while (await requestStream.MoveNext(context.CancellationToken))
            {
                try
                {
                    Console.WriteLine("From client Received: " + requestStream.Current.Message);
                    Console.Write("Send to client: ");
                    await responseStream.WriteAsync(new UserResponse { Message = Console.ReadLine() });
                }catch(Exception ex)
                {
                    Console.WriteLine();
                }
            }
        }

        public override async Task<RealtyListResponse> GetRealtyList(RealtyListRequest request, ServerCallContext context)
        {
            try
            {
                var list = _realtyRepository
                                .ListByName((RealtyTypeEntity)request.Type)
                                .Select(x => _mapper.Map<RealtyAd>(x)).ToList();

                var result = new RealtyListResponse
                {
                    Message = { list }
                };
                return result;
            }catch(Exception ex)
            {
                throw;
            }
        }

        public Task StartAsync<TContext>(IHttpApplication<TContext> application, CancellationToken cancellationToken)
        {
            return null;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return null;
        }

        public void Dispose()
        {
        }
    }
}
