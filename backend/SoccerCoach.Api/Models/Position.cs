
namespace SoccerCoach.Api.Models;

public class Position
{
    public string PositionCode { get; set; } = string.Empty; // "1".."11"
    public string DisplayName { get; set; } = string.Empty;

    public ICollection<PlayerPosition> Players { get; set; } = new List<PlayerPosition>();
}
