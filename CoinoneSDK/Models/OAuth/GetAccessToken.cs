using System;
using System.Net.Http;
using CoinoneSDK.Interfaces;
using Newtonsoft.Json;

namespace CoinoneSDK.Models.OAuth
{
    public class GetAccessToken : IRequestBase
    {
        public GetAccessToken()
        {
        }

        public GetAccessToken(string request_token, string app_id, string app_secret)
        {
            RequestToken = request_token;
            AppId = app_id;
            AppSecret = app_secret;
        }

        [JsonIgnore]
        public string EndPoint => "/oauth/access_token";

        [JsonIgnore]
        public HttpMethod HttpMethod => HttpMethod.Post;

        [JsonProperty("request_token")]
        public string RequestToken { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("app_secret")]
        public string AppSecret { get; set; }

        public string ToPayload()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
