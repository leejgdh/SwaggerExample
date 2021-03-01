using System;
using System.Net.Http;
using CoinoneSDK.Interfaces;
using DHSDK.Helpers;
using Newtonsoft.Json;

namespace CoinoneSDK.Models.Base
{
    public class CoinonePrivateRequestBase : IRequestBase
    {

        public CoinonePrivateRequestBase(string accessToken)
        {
            AccessToken = accessToken;
            Nonce = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);
        }

        //nonce는 timestamp로 ?

        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }

        [JsonProperty("nonce")]
        public long Nonce { get; private set; }

        [JsonIgnore]
        public virtual string EndPoint => throw new NotImplementedException();

        [JsonIgnore]
        public virtual HttpMethod HttpMethod => throw new NotImplementedException();

        public virtual string ToPayload()
        {
            string json = JsonConvert.SerializeObject(this);
            string base_64 = CryptoHelper.Base64Encode(json);
            return base_64;
        }
    }
}
