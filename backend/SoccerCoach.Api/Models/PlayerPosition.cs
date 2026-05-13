
namespace SoccerCoach.Api.Models;

public class PlayerPosition
{
    public int PlayerId { get; set; }
    public Player? Player { get; set; }

    public string PositionCode { get; set; } = string.Empty;
    public Position? Position { get; set; }

    public byte PreferenceLevel { get; set; } = 1; // 1 preferred, 2 ok, 3 emergency
}
