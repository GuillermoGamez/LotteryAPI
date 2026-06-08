using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotteryAPI.Models;

[Table("statuses")]
public class Status
{
    [Key, Column("statusid")]
    public int StatusId { get; set; }
    
    [Column("category")]
    public string Category { get; set; } = string.Empty;
    
    [Column("statusname")]
    public string StatusName { get; set; } = string.Empty;
}