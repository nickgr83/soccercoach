
namespace SoccerCoach.Api.Models;

public class PlanResponse
{
    public int MatchId { get; set; }
    public List<LockedSlot> LockedSlots { get; set; } = new();
    public List<QuarterPlan> Quarters { get; set; } = new();
}

public class LockedSlot
{
    public string Slot { get; set; } = "1";
    public int PlayerId { get; set; }
    public string Reason { get; set; } = string.Empty;
}

public class QuarterPlan
{
    public int SegmentNo { get; set; } // 1..4
    public Dictionary<string, int> Lineup { get; set; } = new(); // positionCode -> playerId
    public List<PlannedSubstitution> Substitutions { get; set; } = new();
}

public class PlannedSubstitution
{
    public int OutPlayerId { get; set; }
    public int InPlayerId { get; set; }
    public string PositionCode { get; set; } = string.Empty;
}
