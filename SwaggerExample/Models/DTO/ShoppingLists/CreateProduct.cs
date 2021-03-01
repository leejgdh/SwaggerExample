using System.ComponentModel.DataAnnotations;

namespace SwaggerExample.Models.DTO.ShoppingLists{

    public struct CreateProduct{

        [StringLength(200)]
        public string Name { get; set; }
        
        public bool IsFavorite{get; set;}

    }
}