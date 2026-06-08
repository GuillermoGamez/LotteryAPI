using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LotteryAPI.Models;

[Table("user_permissions"), PrimaryKey(nameof(UserId), nameof(PermissionId))]
public class UserPermission
{
    [Column("userid")]
    public int UserId { get; set; }
    
    [Column("permissionid")]
    public int PermissionId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    
    [ForeignKey(nameof(PermissionId))]
    public Permission? Permission { get; set; }
}