using System.Net.Http;
using CoinoneSDK.Interfaces;
using CoinoneSDK.Models.Enums;
using Newtonsoft.Json;

namespace CoinoneSDK.Models.Public
{

    public class RequestOrderBook : IRequestBase
    {
        public RequestOrderBook()
        {

        }

        public RequestOrderBook(ECurrency currency)
        {
            Currency = currency;
        }

        [JsonIgnore]
        public string EndPoint => "/orderbook";

        [JsonIgnore]
        public HttpMethod HttpMethod => HttpMethod.Get;


        [JsonProperty("currency")]
        public ECurrency Currency { get; set; }


        public string ToPayload()
        {
            throw new System.NotImplementedException();
        }
    }

}