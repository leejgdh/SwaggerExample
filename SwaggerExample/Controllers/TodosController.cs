using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerExample.Interfaces;
using SwaggerExample.Models.DAO;
using SwaggerExample.Models.DTO;
using SwaggerExample.Models.DTO.Todos;

namespace SwaggerExample.Controllers
{
    /// <summary>
    /// Todo의 내역을 관리합니다.
    /// </summary>
    /// <response code="400">요청값이 잘못됨</response>
    /// <response code="500">Server Error</response>
    [ApiVersion("1.0")]
    [Route ( "api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class TodosController : ControllerBase
    {  
        private readonly ITodoService _todoService;

        public TodosController(
            ITodoService todoService
            )
        {
            _todoService = todoService;
        }

        /// <summary>
        /// 하나의 Todo항목을 가져옵니다.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="header">Signature</param>
        /// <param name="Id">Todo 고유값</param>
        /// <returns></returns>
        /// <response code="200">정상</response>
        /// <response code="404">데이터를 찾을 수 없음</response>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromRoute] Guid Id)
        {
            var result = _todoService.Get(Id);

            if(result == null){
                return NotFound("Content not found");
            }

            return Ok(result);
        }

        /// <summary>
        /// 여러개의 Todo항목을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Todo>),StatusCodes.Status200OK)]
        public IActionResult List()
        {
            var res = _todoService.List();
            
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
        [ProducesResponseType(typeof(Todo), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] RequestCreateTodo req)
        {
            var result = await _todoService.CreateAsync(new CreateTodo(req.Title,req.Content, req.Status));
            
            return Created(nameof(Update), result);
        }


        /// <summary>
        /// Todo를 업데이트 합니다.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <response code="202">업데이트 완료</response>
        [HttpPut]
        [ProducesResponseType(typeof(Todo),StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Update([FromBody] RequestUpdateTodo req)
        {
            
            var result =  await _todoService.UpdateAsync(new UpdateTodo(req.Id, req.Title, req.Content, req.Status));

            if(result == null){
                return NotFound("Content not found");
            }

            return Accepted(result);
        }


        /// <summary>
        /// Todo의 Status를 업데이트 합니다.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <response code="204">업데이트 완료</response>
        /// <response code="404">데이터를 찾을 수 없음</response>
        [HttpPatch("{Id}/Status")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ChangeStatus([FromBody] RequestChangeTodoStatus req)
        {

            var result = await _todoService.ChangeStatusAsync(req.Id, req.Status);

            if(result == null){
                return NotFound("Content not found");
            }

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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete([FromRoute] Guid Id)
        {
            var result = _todoService.DeleteAsync(Id);

            if(result == null){
                return NotFound("Content not found");
            }

            return NoContent();
        }


        [HttpGet]
        [ApiVersion("2.0")]
        [ProducesResponseType(typeof(List<Todo>),StatusCodes.Status200OK)]
        public IActionResult ListV2(){
            
            var result = _todoService.List();

            return Ok(result);
        }
    }
}