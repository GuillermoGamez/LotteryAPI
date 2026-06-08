using LotteryAPI.Db;
using LotteryAPI.Models;
using LotteryAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LotteryAPI.Repository;

public class UserRepository(LotteryContext context) : IUserRepository
{
    public async Task<List<User>> GetAllUsers()
    {
        return await context.Users.Include(u => u.Status).ToListAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await context.Users.FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task<string> CreateUserAsync(User user)
    {
        try
        {
            user.CreatedOn = DateTime.Now.ToUniversalTime();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        
        return "Created";
    }

    public async Task<string> UpdateUserAsync(User updatedUser)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserId == updatedUser.UserId);

            if (user != null)
            {
                user.Email = updatedUser.Email;
                user.Password = updatedUser.Password;
                user.StatusId = updatedUser.StatusId;
                
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
            else
                return "User Not Found";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return "Updated";
    }

    public async Task<string> DeleteUserAsync(int userid)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserId == userid);
            if (user != null)
            {
                var tickets = await context.Tickets.Where(t => t.UserId == userid).ToListAsync();
                if (tickets.Count > 0)
                    context.Tickets.RemoveRange(tickets);
                
                var userPermissions = await context.UserPermissions.Where(u => u.UserId == userid).ToListAsync();
                if (userPermissions.Count > 0)
                    context.UserPermissions.RemoveRange(userPermissions);
                
                context.Users.Remove(user);
                
                await context.SaveChangesAsync();
            }
            else 
                return "User Not Found";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return "Deleted";
    }
}