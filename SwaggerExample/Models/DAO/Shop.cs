using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SwaggerExample.Models.DAO
{

    public class Shop
    {

        public Shop()
        {

        }

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


        public DateTime? LastVisitDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime? DeletedAt { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public List<ShoppingHistory> ShopHistories { get; set; }

    }
}