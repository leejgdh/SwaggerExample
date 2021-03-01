using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using DHDashBoardSDK.Models.Enums;

namespace DHDashBoardSDK.Models.DTO.Todos
{
    public class RequestChangeTodoStatus
    {
        public RequestChangeTodoStatus()
        {
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0}은 필수 입력값입니다.")]
        [EnumDataType(typeof(ETodoStatus))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ETodoStatus Status { get; set; }
    }
}
