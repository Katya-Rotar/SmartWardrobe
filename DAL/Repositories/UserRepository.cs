using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(WardrobeDbContext context) : base(context)
    {
    }
    
    public async Task<User> AuthenticateAsync(string login, string password)
    {
        var userAccount = context.Users.FirstOrDefault(x => x.Email == login);
        if (userAccount != null && userAccount.PasswordHash == password)
        {
            return userAccount;
        }

        return null;
    }
}