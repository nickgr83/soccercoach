
namespace SoccerCoach.Api.Models;

public class MatchEvent
{
    public int MatchEventId { get; set; }
    public int MatchId { get; set; }

    public int? Minute { get; set; }
    public string EventType { get; set; } = "GOAL";

    public int ScorerPlayerId { get; set; }
    public int? AssistPlayerId { get; set; }
}
