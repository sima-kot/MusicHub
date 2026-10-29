using MusicHub.Api.Dtos;
using MusicHub.Api.Models;

namespace MusicHub.Api.Interfaces
{
    public interface ITrackService
    {
        Task<MessageResultDTO> UpdateTrackTitleAsync(UpdateTitleRequest dto);
        

        
    }
}
