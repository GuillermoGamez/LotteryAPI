using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotteryAPI.Models;

[Table("tickets")]
public class Ticket
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("ticketid")]
    public int TicketId { get; set; }
    
    [Column("userid")]
    public int UserId { get; set; }
    
    [Column("statusid")]
    public int StatusId { get; set; }
    
    [Column("ticketdate")]
    public DateTime TicketDate { get; set; }
    
    [Column("createdon")]
    public DateTime CreatedOn { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    
    [ForeignKey(nameof(StatusId))]
    public Status? Status { get; set; }
}