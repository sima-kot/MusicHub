namespace MusicHub.Api.Models
{
    
    public class MessageResultDTO
        
    {
        public bool Result { get; set; }
        public string MessageResult{ get; set; }


        public MessageResultDTO(bool _result, string _messageResult)
        {
            MessageResult = _messageResult;
            Result = _result;
        }
    }
}
