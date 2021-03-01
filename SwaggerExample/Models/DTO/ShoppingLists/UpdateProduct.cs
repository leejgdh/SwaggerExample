using System;
using System.ComponentModel.DataAnnotations;

namespace SwaggerExample.Models.DTO.ShoppingLists
{


    public struct UpdateProduct
    {

        [Key]
        public Guid Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
        
        public bool IsFavorite{get; set;}
    }
}