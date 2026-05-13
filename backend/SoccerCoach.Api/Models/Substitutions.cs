namespace SoccerCoach.Api.Models;

public class Substitution
{
    public int SubstitutionId { get; set; }
    public int MatchId { get; set; }
    public byte SegmentNo { get; set; }          // 1..4 (you’ll use 2..4 mostly)
    public string PositionCode { get; set; } = ""; // "1".."11"
    public int OutPlayerId { get; set; }
    public int InPlayerId { get; set; }

    public bool IsConfirmed { get; set; } = false;
    public bool IsRejected { get; set; } = false;
    public DateTime? DecisionMadeAt { get; set; }
}
