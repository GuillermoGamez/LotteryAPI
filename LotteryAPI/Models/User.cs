using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotteryAPI.Models;

[Table("Users")]
public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("userid")]
    public int UserId { get; set; }
    
    [Column("statusid")]
    public int StatusId { get; set; }
    
    [Length(5, 200), Column("email")]
    public string Email { get; set; } = string.Empty;
    
    [Length(1, 200), Column("password")]
    public string Password { get; set; } = string.Empty;
    
    [Column("createdon")]
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    
    [Column("lastlogin")]
    public DateTime? LastLogin { get; set; } 
    
    [ForeignKey(nameof(StatusId))]
    public Status? Status { get; set; }

    public List<UserPermission> PermissionsList { get; set; } = new();
}