using Microsoft.EntityFrameworkCore;
using ums_dotnet.DbContexts;
using ums_dotnet.Entities;
using ums_dotnet.Models;

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

        public async Task<IEnumerable<User>> GetUsersAsync(UserForFilteringDto searchParams, int pageNumber, int pageSize)
        {
            searchParams.FirstName = searchParams.FirstName.Trim();
            searchParams.LastName = searchParams.LastName.Trim();
            searchParams.UserName = searchParams.UserName.Trim();
            searchParams.Status = searchParams.Status.Trim();
            searchParams.Email = searchParams.Email.Trim();

            var collection = _userContext.Users as IQueryable<User>;

            collection = collection.Where(x =>
                (string.IsNullOrEmpty(searchParams.FirstName) || searchParams.FirstName.ToLower() == x.FirstName.ToLower()) &&
                (string.IsNullOrEmpty(searchParams.LastName) || searchParams.LastName.ToLower() == x.LastName.ToLower()) &&
                (string.IsNullOrEmpty(searchParams.UserName) || searchParams.UserName.ToLower() == x.UserName.ToLower()) &&
                (string.IsNullOrEmpty(searchParams.Email) || searchParams.Email.ToLower() == x.Email.ToLower()) &&
                (string.IsNullOrEmpty(searchParams.Status) || searchParams.Status.ToLower() == x.Status.ToLower()));

            return await collection
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
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
