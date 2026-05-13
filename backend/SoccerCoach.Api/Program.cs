
using Microsoft.EntityFrameworkCore;
using SoccerCoach.Api.Data;
using SoccerCoach.Api.Models;
using SoccerCoach.Api.Services;
using SoccerCoach.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("Sql");
    options.UseSqlServer(cs);
});

builder.Services.AddScoped<PlannerService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

// Players
app.MapGet("/players", async (AppDbContext db) =>
    await db.Players.Where(p => p.IsActive).OrderBy(p => p.DisplayName).ToListAsync());

// Create match (simplified)
app.MapPost("/matches", async (AppDbContext db, Match match) =>
{
    db.Matches.Add(match);
    await db.SaveChangesAsync();
    return Results.Created($"/matches/{match.MatchId}", match);
});

// Add goal event: auto-increment our score
app.MapPost("/matches/{matchId:int}/goal", async (int matchId, AppDbContext db, GoalRequest req) =>
{
    var match = await db.Matches.FindAsync(matchId);
    if (match is null) return Results.NotFound();

    match.OurScore += 1;
    db.MatchEvents.Add(new MatchEvent
    {
        MatchId = matchId,
        Minute = req.Minute,
        EventType = "GOAL",
        ScorerPlayerId = req.ScorerPlayerId,
        AssistPlayerId = req.AssistPlayerId
    });

    await db.SaveChangesAsync();
    return Results.Ok(match);
});

// Generate plan (placeholder)
app.MapPost("/matches/{matchId:int}/generatePlan", async (int matchId, PlannerService planner) =>
{
    var plan = await planner.GeneratePlanAsync(matchId);
    return Results.Ok(plan);
});

// Confirm / reject substitution
app.MapPost("/substitutions/{id:int}/decision", async (int id, DecisionRequest req, AppDbContext db) =>
{
    var sub = await db.Substitutions.FindAsync(id);
    if (sub is null) return Results.NotFound();

    if (req.Decision == "confirm")
        sub.IsConfirmed = true;
    else if (req.Decision == "reject")
        sub.IsRejected = true;

    sub.DecisionMadeAt = DateTime.UtcNow;

    await db.SaveChangesAsync();

    return Results.Ok(sub);
});

// Check if replanning is needed
app.MapGet("/matches/{matchId:int}/needsReplan", async (int matchId, AppDbContext db) =>
{
    var rejectedExists = await db.Substitutions
        .AnyAsync(s => s.MatchId == matchId && s.IsRejected);

    return Results.Ok(new { needsReplan = rejectedExists });
});

// Trigger replanning
app.MapPost("/matches/{matchId:int}/replan", async (int matchId, PlannerService planner) =>
{
    var plan = await planner.GeneratePlanAsync(matchId);
    return Results.Ok(plan);
});



app.Run();
