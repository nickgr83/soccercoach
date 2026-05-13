
namespace SoccerCoach.Api.Models;

public class GoalRequest
{
    public int ScorerPlayerId { get; set; }
    public int? AssistPlayerId { get; set; }
    public int? Minute { get; set; }
}
