using EAuction.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;

namespace EAuction.UnitTests
{
    public class InMemoryAuctionRepositoryTest :AuctionRepositoryTest
    {
        public InMemoryAuctionRepositoryTest() : base(new DbContextOptionsBuilder<ApplicationDbContext>().
                                                UseInMemoryDatabase("TestDb")
                                                         .Options){


        }
      
    }
}
