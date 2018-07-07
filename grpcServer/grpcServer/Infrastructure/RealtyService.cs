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
    }
}
