using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerExample.Models.DTO.Todo;

namespace SwaggerExample.Controllers
{
    /// <summary>
    /// Todo의 내역을 관리합니다.
    /// </summary>
    /// <response code="400">요청값이 잘못됨</response>
    /// <response code="500">Server Error</response>
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class TodosController : ControllerBase
    {

        /// <summary>
        /// 하나의 Todo항목을 가져옵니다.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="Id">Todo 고유값</param>
        /// <returns></returns>
        /// <response code="404">데이터를 찾을 수 없음</response>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseGetTodo))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromRoute] Guid Id)
        {

            var res = new ResponseUpdateTodo();

            return Ok(res);
        }


        /// <summary>
        /// Todo를 생성합니다.
        /// </summary>
        /// <remarks>
        /// 리마크, 함수에 대한 설명을 적습니다.
        /// </remarks>
        /// <param name="req">Request</param>
        /// <returns></returns>
        /// <response code="201">정상</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseCreateTodo))]
        public IActionResult Create([FromBody] RequestCreateTodo req)
        {

            var res = new ResponseCreateTodo(req);

            return CreatedAtRoute("", new { res.Id }, res);
        }


        /// <summary>
        /// Todo를 업데이트 합니다.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <response code="202">업데이트 완료</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(ResponseUpdateTodo))]
        public IActionResult Update([FromBody] RequestUpdateTodo req)
        {

            var res = new ResponseUpdateTodo(req);

            return AcceptedAtRoute("", new { res.Id }, res);
        }


        /// <summary>
        /// Todo의 Status를 업데이트 합니다.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <response code="204">업데이트 완료</response>
        /// <response code="404">데이터를 찾을 수 없음</response>
        [HttpPatch("{Id}/Status")]
        public IActionResult ChangeStatus([FromBody] RequestChangeTodoStatus req)
        {

            return NoContent();
        }


        /// <summary>
        /// Todo를 삭제합니다.
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>s
        /// <response code="204">삭제 완료</response>
        /// <response code="404">데이터를 찾을 수 없음</response>
        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] Guid Id)
        {

            return NoContent();
        }
    }
}