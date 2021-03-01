using System;
namespace DHDashBoardSDK.Models.Base
{
    public class ApiResponseBase<TResponse>
    {
        public ApiResponseBase()
        {
        }

        public bool IsSuccess { get; set; }


        public TResponse Result { get; set; }

        public string Message { get; set; }

        public Guid RequestId { get; set; }
    }
}
