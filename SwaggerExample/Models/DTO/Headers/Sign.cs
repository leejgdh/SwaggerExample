using Microsoft.AspNetCore.Mvc;

namespace SwaggerExample.Models.DTO
{
    public class Sign
    {
        [FromHeader]
        public string Signature { get; set; }
    }


}