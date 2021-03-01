using System;

namespace CoinoneSDK.Models.Base
{

    public class ResponseBase<TResponse>{

        public ResponseBase(){

        }
        public bool IsSuccess { get; set; }

        public TResponse Result { get; set; }

        public string Message { get; set; }

        public Guid RequestId { get; set; }
    }
}