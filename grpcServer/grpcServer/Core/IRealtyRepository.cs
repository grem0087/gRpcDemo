using grpcServer.Data;

namespace grpcServer.Core
{
    public interface IRealtyRepository
    {
        RealtyAdEntity[] ListByName(RealtyTypeEntity names);
    }
}
