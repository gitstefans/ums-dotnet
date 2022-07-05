using Microsoft.EntityFrameworkCore;
using ums_dotnet.DbContexts;
using ums_dotnet.Entities;

namespace ums_dotnet.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userContext.Users.ToListAsync();
        }
        public async Task<User?> GetUserAsync(int id)
        {
            return await _userContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddUserAsync(User user)
        {
            _userContext.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _userContext.Users.Remove(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _userContext.SaveChangesAsync() >= 0);
        }
    }
}
