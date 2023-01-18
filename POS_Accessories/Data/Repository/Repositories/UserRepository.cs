using Microsoft.EntityFrameworkCore;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(AccessoriesDbContext context) : base(context)
        {

        }

        public async Task<User> AuthenticateUser(string email, string password)
        {
            return await _context.Set<User>()
                                   .Where(w => w.Email == email && w.Password == password).FirstOrDefaultAsync();
        }

    }
}
