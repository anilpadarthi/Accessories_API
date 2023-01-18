using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface IUserRepository : IRepository
    {
        Task<User> AuthenticateUser(string email, string password);
    }
}
