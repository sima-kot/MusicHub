using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Mvc;
using MusicHub.Api.Dtos;
using MusicHub.Api.Data;
using MusicHub.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace MusicHub.Api.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class TrackController (AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TrackResponse>>> GetAll()
    {
        var tracks = await db.Tracks
            .AsNoTracking()
            .OrderByDescending(t => t.CreatedAtUtc)
            .Select(t => ToResponse(t))
            .ToListAsync();

        return tracks;
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TrackResponse>> GetById(Guid id)
    {
        var track = await db.Tracks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        return track is null ? NotFound() : ToResponse(track);
    }
    [HttpPost]
    public async Task<ActionResult<TrackResponse>> Create (CreateTrackRequest request)
    {
        var track = new Track { Title = request.Title, Artist = request.Artist };
        db.Tracks.Add(track);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = track.Id }, ToResponse(track));
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var track = await db.Tracks.FindAsync(id);
        if (track is null) return NotFound();

        db.Tracks.Remove(track);
        await db.SaveChangesAsync();
        return NoContent();
    }

    private static TrackResponse ToResponse(Track t) =>
        new(t.Id, t.Title, t.Artist, t.DurationSeconds, t.Status, t.CreatedAtUtc);
}
