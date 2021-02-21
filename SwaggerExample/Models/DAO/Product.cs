using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace SwaggerExample.Models.DAO
{

    public class Product
    {


        public Product()
        {

        }

        [Key]
        public Guid Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
        
        public bool IsFavorite{get; set;}

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime? DeletedAt { get; set; }


        public List<ShoppingHistory> ShopHistories { get; set; }

    }
}