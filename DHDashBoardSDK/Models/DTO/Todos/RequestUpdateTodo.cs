using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using DHDashBoardSDK.Models.Enums;

namespace DHDashBoardSDK.Models.DTO.Todos
{
    public class RequestUpdateTodo : RequestCreateTodo
    {
        public RequestUpdateTodo()
        {
        }

        /// <summary>
        /// 고유값
        /// </summary>
        /// <example>3fa85f64-5717-4562-b3fc-2c963f66afa6</example>
        [Required(ErrorMessage = "{0}은 필수 입력값입니다.")]
        public Guid Id { get; set; }
    }
}
