#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CBeltExam.Models;

public class Mission
{
    [Key]
    public int MissionId { get; set; }
    [Required]
    public int UserId { get; set; }
    public User? User { get; set; }
    [Required]
    public int QuestId { get; set; }
    public Quest? Quest { get; set; }
    [Required]
    public bool IsCompleted { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}