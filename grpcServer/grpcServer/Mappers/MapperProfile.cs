using AutoMapper;
using DowntownRealty;
using grpcServer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace grpcServer.Mappers
{
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RealtyAd, RealtyAdEntity>();
            CreateMap<User, UserEntity>();
            CreateMap<RealtyType, RealtyTypeEntity>();
        }
    }
}
