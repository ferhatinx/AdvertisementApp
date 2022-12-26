using System.Collections.Generic;

namespace Common
{
    public interface IResponseT<T> : IResponse
    {
        T Data {get; set;}       
        List<CustomValidationError> ValidationErrors {get; set;}
    }
}