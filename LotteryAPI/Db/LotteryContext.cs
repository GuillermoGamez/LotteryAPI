using LotteryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LotteryAPI.Db;

public class LotteryContext : DbContext
{
    public LotteryContext(DbContextOptions<LotteryContext> options) : base(options)
    {
        // Required by postgresql if columns have datetime as postgresql doesn't
        // allow timezones. So all date times must be UTC
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<UserPermission> UserPermissions { get; set; }
}