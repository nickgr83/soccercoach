
namespace SoccerCoach.Api.Models;

public class Match
{
    public int MatchId { get; set; }
    public DateOnly MatchDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public string? Opponent { get; set; }
    public string? HomeAway { get; set; }

    public int OurScore { get; set; } = 0;
    public int TheirScore { get; set; } = 0;
}
