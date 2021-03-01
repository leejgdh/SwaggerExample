using System;
using System.Net.Http;
using CoinoneSDK.Interfaces;
using CoinoneSDK.Models.Enums;
using Newtonsoft.Json;

namespace CoinoneSDK.Models.Public
{
    public class RequestTicker : IRequestBase
    {
        public RequestTicker()
        {
        }

        public RequestTicker(ECurrency currency)
        {
            Currency = currency;
        }


        [JsonIgnore]
        public string EndPoint => "/ticker";

        [JsonIgnore]
        public HttpMethod HttpMethod => HttpMethod.Get;


        [JsonProperty("currency")]
        public ECurrency Currency { get; set; }


        public string ToPayload()
        {
            throw new NotImplementedException();
        }
    }
}
