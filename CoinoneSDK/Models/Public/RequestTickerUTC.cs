﻿using System;
using System.Net.Http;
using CoinoneSDK.Interfaces;
using CoinoneSDK.Models.Enums;
using Newtonsoft.Json;

namespace CoinoneSDK.Models.Public
{
    public class RequestTickerUTC : IRequestBase
    {
        public RequestTickerUTC()
        {
        }


        public RequestTickerUTC(ECurrency currency)
        {
            Currency = currency;
        }


        [JsonIgnore]
        public string EndPoint => "/ticker_utc";

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
