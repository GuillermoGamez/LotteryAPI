using LotteryAPI.Models;

namespace LotteryAPI.Repository.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    
    Task<User?> GetUserByEmail(string email);
    
    Task<string> CreateUserAsync(User user);

    Task<string> UpdateUserAsync(User user);
    
    Task<string> DeleteUserAsync(int userid);
}