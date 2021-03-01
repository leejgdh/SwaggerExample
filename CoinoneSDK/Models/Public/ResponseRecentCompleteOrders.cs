using System;
using System.Collections.Generic;
using CoinoneSDK.Models.Base;
using Newtonsoft.Json;

namespace CoinoneSDK.Models.Public
{
    public class ResponseRecentCompleteOrders : CoinoneResponseBase
    {
        public ResponseRecentCompleteOrders()
        {
        }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("completeOrders")]
        public List<CompleteOrder> CompleteOrders { get; set; }
    }


    public class CompleteOrder
    {
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("qty")]
        public string Qty { get; set; }

        [JsonProperty("is_ask")]
        public string IsAsk { get; set; }
    }
}
