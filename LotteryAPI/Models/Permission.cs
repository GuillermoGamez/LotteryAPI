using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotteryAPI.Models;

[Table("permissions")]
public class Permission
{
    [Key, Column("permissionid")]
    public int PermissionId  { get; set; }
    
    [Column("permissionname")]
    public string PermissionName { get; set; } = string.Empty;
}