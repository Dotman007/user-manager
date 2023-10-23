using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Dto;

namespace UserManager.Application.ResponseHelper
{
    public static class ResponseHelperService
    {
        public static ResponseInfo<T> Error<T>(string message, string statusCode)
        {
            return new ResponseInfo<T>
            {
                ResponseMessage = message,
                ResponseCode = statusCode
            };
        }

        public static ResponseInfo<T> Success<T>(T data, string message, string statusCode)
        {
            return new ResponseInfo<T>
            {
                Data = data,
                ResponseMessage = message,
                ResponseCode = statusCode
            };
        }
    }
}
