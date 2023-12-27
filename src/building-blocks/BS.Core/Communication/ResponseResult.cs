namespace BS.Core.Communication
{
    public class ResponseResult
    { 
        public ResponseResult()
        {
            Errors = new ResponseErrorMessages();
        }

        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessages Errors { get; }
    }

    public class ResponseErrorMessages
    {
        public ResponseErrorMessages()
        {
            Messages = new List<string>();
        }

        public ResponseErrorMessages(List<string> messages)
        {
            Messages = messages;
        }

        public List<string> Messages { get; set; }
    }
}
