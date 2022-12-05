namespace Common
{
    public class Response : IResponse
    {
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }

        public Response(ResponseType responsetype)
        {
            ResponseType = responsetype;
        }
        public Response(ResponseType responsetype, string message)
        {
            ResponseType = responsetype;
            Message = message;
        }

    }
    public enum ResponseType
    {
        Success,
        ValidationError,
        NotFound
    }
}