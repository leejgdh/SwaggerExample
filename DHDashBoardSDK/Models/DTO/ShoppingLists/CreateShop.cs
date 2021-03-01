

using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using DHDashBoardSDK.Interfaces;
using Newtonsoft.Json;

namespace DHDashBoardSDK.Models.DTO.ShoppingLists
{

    public struct CreateShop : IRequestBase
    {

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(200)]
        public string Address2 { get; set; }

        [StringLength(6)]
        public string PostCode { get; set; }

        public double? Lat { get; set; }

        public double? Lan { get; set; }

        [JsonIgnore]
        public string EndPoint => "/api/v1/ShoppingLists/Shop";

        [JsonIgnore]
        public HttpMethod HttpMethod => HttpMethod.Post;

        public string ToPayload()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}