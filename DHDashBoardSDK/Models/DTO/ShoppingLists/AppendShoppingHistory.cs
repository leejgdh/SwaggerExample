using System;
using System.ComponentModel.DataAnnotations;

namespace DHDashBoardSDK.Models.DTO.ShoppingLists{

    public struct AppendShoppingHistory{

        [Required]
        public int Price { get; set; }

        [Required]
        public int Qty { get; set; }

        public DateTime? ShopDate { get; set; }

        public Guid ShopId { get; set; }

        public Guid ProductId { get; set; }

    }
}