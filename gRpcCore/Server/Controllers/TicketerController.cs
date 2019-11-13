using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Ticket;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class TicketerController
    {
        private ITicketerService _ticketerService;
        public TicketerController(ITicketerService ticketerService)
        {
            _ticketerService = ticketerService;
        }
        
        [HttpGet]
        public async Task<AvailableTicketsResponse> GetAvailableTickets()
        {
            var result = await _ticketerService.GetAvailableTickets(new Empty(), null);
            return result;
        }
    }
}
