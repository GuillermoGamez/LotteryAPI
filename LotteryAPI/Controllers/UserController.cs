using LotteryAPI.Models;
using LotteryAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LotteryAPI.Controllers;

[ApiController, Route("[controller]")]
public class UserController(IUserRepository userRepository) : Controller
{
    [HttpGet, Route("GetAllUsers")]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var users = await userRepository.GetAllUsers();
        return Ok(users);
    }

    [HttpGet, Route("GetUserByEmail/{email}")]
    public async Task<ActionResult> GetUserByEmail(string email)
    {
        var user = await userRepository.GetUserByEmail(email);
        return user != null ? Ok(user) : NotFound("User not found");
    }

    [HttpPost, Route("CreateUser")]
    public async Task<ActionResult> CreateUser(User newUser)
    {
        var msg = await userRepository.CreateUserAsync(newUser);
        return msg == "Created" ? Ok(msg) : Conflict(msg);
    }

    [HttpPost, Route("UpdateUser")]
    public async Task<ActionResult> UpdateUser(User updatedUser)
    {
        var msg = await userRepository.UpdateUserAsync(updatedUser);
        return msg == "Updated" ? Ok(msg) : Conflict(msg);
    }

    [HttpDelete, Route("DeleteUser/{userId:int}")]
    public async Task<ActionResult> DeleteUser(int userId)
    {
        var msg = await userRepository.DeleteUserAsync(userId);
        return msg == "Deleted" ? Ok(msg) : Conflict(msg);
    }
}