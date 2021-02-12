using System.Net.Mime;
using System.ComponentModel.DataAnnotations;
using SwaggerExample.Models.Enums;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace SwaggerExample.Models.DTO.Todos
{

    public class CreateTodo
    {
        public CreateTodo()
        {

        }

        public CreateTodo(string title, string content, ETodoStatus? status)
        {
            Title = title;
            Content = content;
            Status = status;
        }

        /// <summary>
        /// 타이틀
        /// </summary>
        /// <example>타이틀</example>
        [Required(ErrorMessage = "{0}은 필수 입력값입니다.")]
        [Display(Name = "타이틀")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "{0}의 길이는 최대 {1} 최소 {2} 입니다.")]
        public string Title { get; set; }
        
        /// <summary>
        /// 본문내용
        /// </summary>
        /// <example>본문 컨텐츠 입력</example>
        [Required(ErrorMessage = "{0}은 필수 입력값입니다.")]
        [Display(Name = "본문")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "{0}의 길이는 최대 {1} 최소 {2} 입니다.")]
        public string Content { get; set; }

        [EnumDataType(typeof(ETodoStatus))]        
        [JsonConverter(typeof(StringEnumConverter))]
        public ETodoStatus? Status { get; set; }
    }
}