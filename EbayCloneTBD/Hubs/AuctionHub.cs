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
        public async Task GetUpdateForAuction(string Id)
        {
            int id = Int32.Parse(Id);
            Auction auction;
                auction = _auctionRepository.EndAuction(id);

                await Clients.Caller.SendAsync("ReceiveOrderUpdate",auction);
                Thread.Sleep(1000);
                
           // await Clients.Caller.SendAsync("Finished");
        }
    }

}
