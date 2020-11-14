using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common.Helper;

namespace OnlineShop.Common.Result
{
    public class Result<T>
    {
        public T Data { get; private set; }
        public string Message { get; set; }

        public ObjectResult ApiResult { get; set; }
        public bool Success { get; set; }

        public object Parameter { get; set; }

        public static Result<T> SuccessFull(T data, object parameter = null) => new Result<T> { ApiResult = new OkObjectResult(data), Data = data, Message = null, Success = true, Parameter = parameter };

        public static Result<T> SuccessFull(ObjectResult success = null) => new Result<T> { ApiResult = success, Message = null, Success = true };
        public static Result<T> Failed(ObjectResult error) => new Result<T> { ApiResult = error, Success = false, Message = error.Value?.ToString() };

        public static Result<T> Failed(ApiMessage apiMessage) => new Result<T> { Success = false, Message = apiMessage.Message };

    }

    public class Result
    {
        public string Message { get; set; }

        public ObjectResult ApiResult { get; set; }
        public bool Success { get; set; }

        public static Result SuccessFull(ObjectResult success = null) => new Result { ApiResult = success, Message = null, Success = true };

        public static Result SuccessFull(ApiMessage apiMessage) => new Result { Message = apiMessage.Message, Success = true };
        public static Result Failed(ObjectResult error) => new Result { ApiResult = error, Success = false, Message = error.Value?.ToString() };
        public static Result Failed(ApiMessage apiMessage) => new Result { Success = false, Message = apiMessage.Message };

    }
}