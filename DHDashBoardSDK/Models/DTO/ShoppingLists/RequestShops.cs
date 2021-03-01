using System;
using System.Net.Http;
using DHDashBoardSDK.Interfaces;
using Newtonsoft.Json;

namespace DHDashBoardSDK.Models.DTO.ShoppingLists
{
    public class RequestShops : IRequestBase
    {
        public RequestShops()
        {
        }

        [JsonIgnore]
        public string EndPoint => "/api/v1/ShoppingLists/Shop";

        [JsonIgnore]
        public HttpMethod HttpMethod => HttpMethod.Get;

        public string ToPayload()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
