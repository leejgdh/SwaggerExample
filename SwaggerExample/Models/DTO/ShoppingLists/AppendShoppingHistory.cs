using System;
using System.ComponentModel.DataAnnotations;

namespace SwaggerExample.Models.DTO.ShoppingLists{

    public class AppendShoppingHistory{

        [Required]
        public int Price { get; set; }

        [Required]
        public int Qty { get; set; }

        public DateTime? ShopDate { get; set; }

        public Guid ShopId { get; set; }

        public Guid ProductId { get; set; }

    }
}