using System;
using System.ComponentModel.DataAnnotations;

namespace SwaggerExample.Models.DTO.ShoppingLists
{


    public class UpdateProduct : CreateProduct
    {
        
        public UpdateProduct()
        {
            
        }


        [Key]
        public Guid Id { get; set; }
    }
}