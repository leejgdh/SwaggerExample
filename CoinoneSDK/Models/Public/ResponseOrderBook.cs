using System.Collections.Generic;
using CoinoneSDK.Models.Base;
using CoinoneSDK.Models.Enums;
using Newtonsoft.Json;

namespace CoinoneSDK.Models.Public
{

    public class ResponseOrderBook : CoinoneResponseBase
    {
        [JsonProperty("currency")]
        public ECurrency Currency { get; set; }

        [JsonProperty("bid")]
        public List<OrderBookItem> Bid { get; set; }

        [JsonProperty("ask")]
        public List<OrderBookItem> Ask { get; set; }
    }


    public class OrderBookItem
    {
        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("qty")]
        public string Qty { get; set; }
    }
}