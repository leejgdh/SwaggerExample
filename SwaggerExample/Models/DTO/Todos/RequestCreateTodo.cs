using System.ComponentModel.DataAnnotations;

namespace SwaggerExample.Models.DTO.Todos
{
    public class RequestCreateTodo
    {
        public RequestCreateTodo()
        {
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
    }
}
