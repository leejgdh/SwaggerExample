using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace CoinoneSDK.Interfaces
{
    public interface IRequestBase
    {
        [JsonIgnore]
        string EndPoint { get; }

        [JsonIgnore]
        HttpMethod HttpMethod { get; }

        string ToPayload();
    }
}
