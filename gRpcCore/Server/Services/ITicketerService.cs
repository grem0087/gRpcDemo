using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Ticket;

namespace Server
{
    public interface ITicketerService
    {
        Task<AvailableTicketsResponse> GetAvailableTickets(Empty request, ServerCallContext context);
        Task<BuyTicketsResponse> BuyTickets(BuyTicketsRequest request, ServerCallContext context);
    }
}