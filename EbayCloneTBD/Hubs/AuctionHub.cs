using EbayCloneTBD.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EAuction.Hubs
{
    public class AuctionHub :Hub
    {
        private readonly IAuctionRepository _auctionRepository;
        public AuctionHub(IAuctionRepository auctionRepository)
        {
           _auctionRepository = auctionRepository;
        }
        public async Task GetUpdateForOrder(string orderId)
        {
            int id = Int32.Parse(orderId);
            Auction auction;
                auction = _auctionRepository.Update(id);

                await Clients.Caller.SendAsync("ReceiveOrderUpdate",auction);
                Thread.Sleep(1000);
                
           // await Clients.Caller.SendAsync("Finished");
        }
    }

}
