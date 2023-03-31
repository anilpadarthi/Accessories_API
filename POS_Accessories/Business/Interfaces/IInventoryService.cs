using AutoMapper;
using POS_Accessories.Business.Helper;
using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;
using System.Net;

namespace POS_Accessories.Business.Interfaces
{
    public interface IInventoryService
    {
        Task<CommonResponse> GetWareHouseResultAsync(GetPagedSearch request);
        Task<CommonResponse> GetStockPurchaseHistoyResultAsync(GetPagedSearch request);
    }
}
