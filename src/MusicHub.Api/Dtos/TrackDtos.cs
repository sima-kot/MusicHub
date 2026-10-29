using Microsoft.AspNetCore.Mvc;
using MusicHub.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Api.Dtos
{
    public record CreateTrackRequest(
        [Required, StringLength(200)] string Title,
        [StringLength(200)] string? Artist);
    public record TrackResponse(
       Guid Id,
       string Title,
       string? Artist,
       int? DurationSeconds,
       TrackStatus Status,
       DateTime CreatedAtUtc);
}

        






