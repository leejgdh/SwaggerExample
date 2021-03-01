using System;
using CoinoneSDK.Models.Base;
using Newtonsoft.Json;

namespace CoinoneSDK.Models.Public
{
    public class ResponseTicker : CoinoneResponseBase
    {
        public ResponseTicker()
        {
        }


        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("high")]
        public string High { get; set; }

        [JsonProperty("low")]
        public string Low { get; set; }

        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }

        [JsonProperty("yesterday_high")]
        public string YesterdayHigh { get; set; }

        [JsonProperty("yesterday_low")]
        public string YesterdayLow { get; set; }

        [JsonProperty("yesterday_first")]
        public string YesterdayFirst { get; set; }

        [JsonProperty("yesterday_last")]
        public string YesterdayLast { get; set; }

        [JsonProperty("yesterday_volume")]
        public string YesterdayVolume { get; set; }
    }
}
