using LotteryAPI.Db;
using LotteryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LotteryAPI.Controllers;

[ApiController, Route("[controller]")]
public class PermissionController(LotteryContext context) : Controller
{
    [HttpGet, Route("GetAllPermissions")]
    public async Task<ActionResult<List<Permission>>> GetAllPermissions()
    {
        return await context.Permissions.ToListAsync();
    }
}