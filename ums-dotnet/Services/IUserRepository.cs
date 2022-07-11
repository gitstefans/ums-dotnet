using ums_dotnet.Entities;
using ums_dotnet.Models;

namespace ums_dotnet.Services
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<User>> GetUsersAsync(UserForFilteringDto searchParams, int pageNumber, int pageSize);
        Task<User?> GetUserAsync(int id);
        Task AddUserAsync(User user);
        void DeleteUser(User user);
        Task<bool> SaveChangesAsync();
    }
}
