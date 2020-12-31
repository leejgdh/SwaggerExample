using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SwaggerExample.Models.Enums;

namespace SwaggerExample.Models.DTO.Todos
{
    public class RequestChangeTodoStatus
    {
        public RequestChangeTodoStatus()
        {
        }

        [Required(ErrorMessage = "{0}은 필수 입력값입니다.")]
        [EnumDataType(typeof(ETodoStatus))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ETodoStatus Status { get; set; }
    }
}
