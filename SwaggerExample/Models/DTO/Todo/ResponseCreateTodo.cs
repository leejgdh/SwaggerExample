using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SwaggerExample.Models.Enums;

namespace SwaggerExample.Models.DTO.Todo
{
    public class ResponseCreateTodo
    {
        public ResponseCreateTodo()
        {
        }

        public ResponseCreateTodo(RequestCreateTodo req)
        {
            Id = Guid.NewGuid();
            Title = req.Title;
            Content = req.Content;
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// 고유값
        /// </summary>
        /// <example>3fa85f64-5717-4562-b3fc-2c963f66afa6</example>
        public Guid Id { get; set; }

        /// <summary>
        /// 타이틀
        /// </summary>
        /// <example>타이틀</example>
        [Display(Name = "타이틀")]
        public string Title { get; set; }


        /// <summary>
        /// 본문
        /// </summary>
        /// <example>본문</example>
        [Display(Name = "본문")]
        public string Content { get; set; }

        /// <summary>
        /// 상태
        /// </summary>
        /// <example>ACTIVE</example>
        [Required(ErrorMessage = "{0}은 필수 입력값입니다.")]
        [EnumDataType(typeof(ETodoStatus))]
        [JsonConverter(typeof(StringEnumConverter))]
        public ETodoStatus Status { get; set; }

        /// <summary>
        /// 작성일
        /// </summary>
        /// <example>2020-01-01</example>
        [Display(Name = "작성일")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
    }
}
