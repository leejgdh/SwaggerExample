using System;
using System.Net.Http;
using CoinoneSDK.Interfaces;
using CoinoneSDK.Models.Base;
using Newtonsoft.Json;

namespace CoinoneSDK.Models.Account
{
    public class RequestBalance : CoinonePrivateRequestBase
    {
        public RequestBalance(string accessToken) : base(accessToken)
        {

        }

        [JsonIgnore]
        public override string EndPoint => "/v2/account/balance";

        [JsonIgnore]
        public override HttpMethod HttpMethod => HttpMethod.Post;

    }
}
