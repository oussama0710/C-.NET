#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CBeltExam.Models;
public class Quest
{
    // ---------------------ID--------------------------
    [Key]
    public int QuestId { get; set; }
    // ---------------------Foreign-Key--------------------------
    public int UserId { get; set; }
    // Navigation Property : creator
    public User? Creator { get; set; }

    // ---------------------Title------------------------------------
    [Required]
    public string Title { get; set; } 
    // ---------------------Reward------------------------------------
    [Required]
    public int Reward { get; set; } 

    // ------------------------Description---------------------------------
    [Required]
    public string Description { get; set; }
    
    public int PeopleOnQuest { get; set; } =0;
    // -----------------------Created At--------------------------------
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // ----------------------------Updated At-------------------------------
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // ! Navigation Properties 
    // * Missions I'm in 
    public List<Mission> MissionsIn { get; set; } = new List<Mission>();
}
