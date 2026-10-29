using System.ComponentModel.DataAnnotations;

namespace MusicHub.Api.Models
{
    public enum TrackStatus
    {
        Pending =0,
        Ready = 1,
        Failed = 2
    }

    public class Track
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string? Artist { get; set; }
        public int? DurationSeconds { get; set; }

        public string? StorageKey { get; set; }

        public TrackStatus Status { get; set; } = TrackStatus.Pending;
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
