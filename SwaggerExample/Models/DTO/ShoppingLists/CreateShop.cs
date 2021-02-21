

using System.ComponentModel.DataAnnotations;

namespace SwaggerExample.Models.DTO.ShoppingLists
{

    public class CreateShop
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

    }
}