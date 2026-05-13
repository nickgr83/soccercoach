
namespace SoccerCoach.Api.Models;

public class Player
{
    public int PlayerId { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    public ICollection<PlayerPosition> Positions { get; set; } = new List<PlayerPosition>();
}
