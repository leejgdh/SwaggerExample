using System;
using System.ComponentModel.DataAnnotations;

namespace DHDashBoardSDK.Models.DTO.ShoppingLists
{
    public struct UpdateShop
    {

        [Key]
        public Guid Id { get; set; }

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