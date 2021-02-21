using System;
using System.ComponentModel.DataAnnotations;


namespace SwaggerExample.Models.DAO
{

    public class ShoppingHistory
    {

        public ShoppingHistory()
        {

        }

        [Key]
        public int Id { get; set; }
        
        public int Price { get; set; }

        public int Qty { get; set; }

        public DateTime? ShopDate { get; set; }

        public Guid ShopId { get; set; }

        public Guid ProductId { get; set; }

        public DateTime CreatedAt { get; set; }

        public Product Product { get; set; }

        public Shop Shop { get; set; }

    }
}