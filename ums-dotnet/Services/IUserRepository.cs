using ums_dotnet.Entities;

namespace ums_dotnet.Services
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserAsync(int id);
        Task AddUserAsync(User user);
        void DeleteUser(User user);
        Task<bool> SaveChangesAsync();
    }
}
