using grpcServer.Data;

namespace grpcServer.Core
{
    public interface IRealtyService
    {
        RealtyAdEntity[] GetRealtyList(int type);
    }
}
