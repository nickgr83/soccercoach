
using Microsoft.EntityFrameworkCore;
using SoccerCoach.Api.Data;
using SoccerCoach.Api.Models;

namespace SoccerCoach.Api.Services;

public class PlannerService
{
    private readonly AppDbContext _db;

    public PlannerService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<PlanResponse> GeneratePlanAsync(int matchId)
    {
        // Placeholder implementation:
        // - Demonstrates GK lock rule: if only one GK exists, lock slot #1
        // - Returns empty quarter plans (real algorithm to be added)

        var squadPlayerIds = await _db.Players.Where(p => p.IsActive).Select(p => p.PlayerId).ToListAsync();

        var gkIds = await _db.PlayerPositions
            .Where(pp => pp.PositionCode == "1")
            .Select(pp => pp.PlayerId)
            .Distinct()
            .ToListAsync();

        var resp = new PlanResponse { MatchId = matchId };

        if (gkIds.Count == 1)
        {
            resp.LockedSlots.Add(new LockedSlot
            {
                Slot = "1",
                PlayerId = gkIds[0],
                Reason = "Only one GK in squad (stub logic: using all active players)"
            });
        }

        for (var q = 1; q <= 4; q++)
        {
            resp.Quarters.Add(new QuarterPlan
            {
                SegmentNo = q,
                Lineup = new Dictionary<string, int>(),
                Substitutions = new List<PlannedSubstitution>()
            });
        }

        return resp;
    }
}
