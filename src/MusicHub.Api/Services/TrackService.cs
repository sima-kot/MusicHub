

using Microsoft.EntityFrameworkCore;
using MusicHub.Api.Data;
using MusicHub.Api.Dtos;
using MusicHub.Api.Interfaces;
using MusicHub.Api.Models;

namespace MusicHub.Api.Services
{
    public class TrackService : ITrackService
    {
        private readonly AppDbContext _dbContext;
        public TrackService(AppDbContext dbContext) 
        {
            _dbContext=dbContext;   
        }
        public async Task<MessageResultDTO> UpdateTrackTitleAsync(UpdateTitleRequest dto)
        {
            var entity =
                await _dbContext.Tracks.FirstOrDefaultAsync(t =>
                t.Id == dto.Id);

            if (entity == null)
            {
                return new MessageResultDTO(false, $"{nameof(Track)}, Not found");
            }
            entity.Title = dto.Title;

            await _dbContext.SaveChangesAsync();

            return new MessageResultDTO(true, "success");
            
        }
    }
}
