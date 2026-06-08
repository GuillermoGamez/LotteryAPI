using LotteryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LotteryAPI.Db;

public class LotteryContext(DbContextOptions<LotteryContext> options) : DbContext(options)
{
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<UserPermission> UserPermissions { get; set; }
}