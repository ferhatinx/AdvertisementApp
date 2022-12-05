using System.Collections.Generic;

namespace Common
{
    public class Response<T> : Response
    {
        

        public T Data {get; set;}       
        public List<CustomValidationError> ValidationErrors {get; set;}
       public Response(ResponseType responsetype, string message) : base(responsetype, message)
        {
        }
        public Response(ResponseType responsetype,T data) : base(responsetype)
        {
            Data = data;
        }
        public Response(ResponseType responsetype, T data,List<CustomValidationError> errors) : base(ResponseType.ValidationError)
        {
            ValidationErrors =errors;
            Data =data;
        }
    
    }
}