using System;
using System.Net.Mime;
using System.Threading.Tasks;
using DHDashBoardSDK.Models.DTO.ShoppingLists;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerExample.Interfaces;

namespace SwaggerExample.Controllers
{
    /// <summary>
    /// Todo의 내역을 관리합니다.
    /// </summary>
    /// <response code="400">요청값이 잘못됨</response>
    /// <response code="500">Server Error</response>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ShoppingListsController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListsController(
            IShoppingListService shoppingListService
            )
        {
            _shoppingListService = shoppingListService;
        }

        /// <summary>
        /// Get Shops List
        /// </summary>
        /// <returns></returns>
        [HttpGet("Shop")]
        public IActionResult GetShops()
        {
            var result = _shoppingListService.GetShops();
            return Ok(result);
        }


        /// <summary>
        /// Get Shop From ShopId
        /// </summary>
        /// <param name="ShopId"></param>
        /// <returns></returns>
        [HttpGet("Shop/{ShopId}")]
        public IActionResult GetShop([FromRoute] Guid ShopId)
        {

            var result = _shoppingListService.GetShop(ShopId);
            return Ok(result);
        }


        /// <summary>
        /// Creat Shop
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("Shop")]
        public async Task<IActionResult> CreateShop([FromBody] CreateShop req)
        {

            var result = await _shoppingListService.CreateShopAsync(req);

            return Created(nameof(GetShop), result);
        }

        /// <summary>
        /// Update Shop
        /// </summary>
        /// <param name="ShopId"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut("Shop/{ShopId}")]
        public async Task<IActionResult> UpdateShop([FromRoute] Guid ShopId, [FromBody] UpdateShop req)
        {

            if (ShopId != req.Id)
            {
                return BadRequest("Shop Id not matched");
            }

            var result = await _shoppingListService.UpdateShopAsync(req);

            return Accepted(result);
        }

        /// <summary>
        /// Delete Shop From Shop Id
        /// </summary>
        /// <param name="ShopId"></param>
        /// <returns></returns>
        [HttpDelete("Shop/{ShopId}")]
        public IActionResult DeleteShop([FromRoute] Guid ShopId)
        {

            _shoppingListService.DeleteShop(ShopId);

            return NoContent();
        }

        /// <summary>
        /// Get Product List
        /// </summary>
        /// <returns></returns>
        [HttpGet("Product")]
        public IActionResult GetProducts()
        {

            var result = _shoppingListService.GetProducts();

            return Ok(result);
        }

        /// <summary>
        /// Get Product from Product Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet("Product/{ProductId}")]
        public IActionResult GetProduct([FromRoute] Guid ProductId)
        {

            var result = _shoppingListService.GetProduct(ProductId);

            return Ok(result);
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("Product")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct req)
        {

            var result = await _shoppingListService.CreateProductAsync(req);

            return Created(nameof(GetProduct), result);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut("Product/{ProductId}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid ProductId, [FromBody] UpdateProduct req)
        {

            if (ProductId != req.Id)
            {
                return BadRequest("Product Id not matched");
            }

            var result = await _shoppingListService.UpdateProductAsync(req);

            return Accepted(result);
        }

        /// <summary>
        /// Delete product from productId
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpDelete("Product/{ProductId}")]
        public IActionResult DeleteProduct([FromRoute] Guid ProductId)
        {

            _shoppingListService.DeleteProduct(ProductId);

            return NoContent();
        }

        /// <summary>
        /// Append Shopping History
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("ShoppingHistory")]
        public IActionResult AppendShoppingHistory([FromBody] AppendShoppingHistory req)
        {
            _shoppingListService.AppendShoppingHistory(req);

            return NoContent();
        }
    }
}