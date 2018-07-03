using grpcServer.Core;
using static DowntownRealty.DowntownRealty;
using grpcServer.Data;
using AutoMapper;
using System.Linq;

namespace grpcServer.Infrastructure
{
    public class RealtyServiceImpl : DowntownRealtyBase
    {
        IRealtyRepository _realtyRepository;
        IMapper _mapper;

        public RealtyServiceImpl(IRealtyRepository realtyRepository)
        {
            _realtyRepository = realtyRepository;
        }

        public RealtyAdEntity[] GetRealtyList(int type)
        {
            var list = _realtyRepository.ListByName((RealtyTypeEntity)type);
            var result = list.Select(x => _mapper.Map<RealtyAdEntity>(x)).ToArray();
            return result;
        }
    }
}
