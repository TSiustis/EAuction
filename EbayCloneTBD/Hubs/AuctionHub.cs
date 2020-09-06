using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Hubs
{
    public class AuctionHub :Hub
    {
        public async Task SendMessage(DateTime TimeLeft)
        {
            await Clients.All.SendAsync("ReceiveMessage", TimeLeft);
        }
    }
}
