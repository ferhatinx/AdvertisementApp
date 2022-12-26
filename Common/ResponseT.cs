using System.Collections.Generic;

namespace Common
{
    public class ResponseT<T> : Response,IResponseT<T>
    {
        

        public T Data {get; set;}       
        public List<CustomValidationError> ValidationErrors {get; set;}
       public ResponseT(ResponseType responsetype, string message) : base(responsetype, message)
        {
        }
        public ResponseT(ResponseType responsetype,T data) : base(responsetype)
        {
            Data = data;
        }
        public ResponseT(T data,List<CustomValidationError> errors) : base(ResponseType.ValidationError)
        {
            ValidationErrors =errors;
            Data =data;
        }
    
    }
}