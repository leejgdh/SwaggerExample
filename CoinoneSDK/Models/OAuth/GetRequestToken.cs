using System;
using System.Net.Http;
using CoinoneSDK.Interfaces;
using Newtonsoft.Json;

namespace CoinoneSDK.Models.OAuth
{
    public class GetRequestToken : IRequestBase
    {
        public GetRequestToken(string app_id)
        {
            AppId = app_id;
        }


        [JsonIgnore]
        public string EndPoint => "/account/login";

        [JsonIgnore]
        public HttpMethod HttpMethod => throw new NotImplementedException();

        [JsonProperty("app_id")]
        [JsonRequired]
        public string AppId { get; set; }

        public string ToPayload()
        {
            throw new NotImplementedException();
        }
    }
}
