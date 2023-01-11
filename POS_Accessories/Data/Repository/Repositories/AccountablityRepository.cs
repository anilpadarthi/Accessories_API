using Microsoft.EntityFrameworkCore;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class AccountablityRepository : Repository, IStockAllocationRepository
    {
        public AccountablityRepository(AccessoriesDbContext context) : base(context)
        {
        }

        


    }
}
