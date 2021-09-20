using Data.Models.Mapping.Responses;
using System;

namespace Helpers.ResponseWrapper
{
    public class ResponseWrapper<T>
    {
        public static Response<T> Create(T data)
        {
            return new Response<T>()
            {
                Data = data,
                Status = ApiResponseStatus.Ok
            };
        }

        public static Response<T> Create(Exception exception)
        {
            return new Response<T>()
            {
                Status = ApiResponseStatus.Error,
                ErrorCode = exception.HResult,
                Message = exception.Message
            };
        }
    }
}
