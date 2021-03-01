using Newtonsoft.Json;

namespace CoinoneSDK.Models.Base
{

    public class CoinoneResponseBase
    {

        public CoinoneResponseBase()
        {

        }

        public CoinoneResponseBase(string response)
        {

        }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("errorMsg")]
        public string ErrorMsg { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}