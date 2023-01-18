using POS_Accessories.Models.Response;

namespace POS_Accessories.Business.Interfaces
{
    public interface IUserService
    {
        Task<CommonResponse> AuthenticateUser(string email, string password);
    }
}
