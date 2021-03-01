using System.Linq;
using System;
using System.Threading.Tasks;
using SwaggerExample.Models.DAO;
using DHDashBoardSDK.Models.DTO.ShoppingLists;

namespace SwaggerExample.Interfaces
{

    public interface IShoppingListService
    {

        /// <summary>
        /// Get Shops
        /// </summary>
        /// <returns></returns>
        IQueryable<Shop> GetShops();

        /// <summary>
        /// Get shop From PK
        /// </summary>
        /// <param name="ShopId"></param>
        /// <returns></returns>
        Shop GetShop(Guid ShopId);

        /// <summary>
        /// Create Shop
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<Shop> CreateShopAsync(CreateShop req);

        /// <summary>
        /// Update Shop
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<Shop> UpdateShopAsync(UpdateShop req);

        /// <summary>
        /// Delete Shop
        /// </summary>
        /// <param name="ShopId"></param>
        void DeleteShop(Guid ShopId);

        /// <summary>
        /// Get Product List
        /// </summary>
        /// <returns></returns>
        IQueryable<Product> GetProducts();

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        Product GetProduct(Guid ProductId);


        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<Product> CreateProductAsync(CreateProduct req);


        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<Product> UpdateProductAsync(UpdateProduct req);

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="ProductId"></param>
        void DeleteProduct(Guid ProductId);

        /// <summary>
        /// Append Shopping History
        /// </summary>
        /// <param name="req"></param>
        void AppendShoppingHistory(AppendShoppingHistory req);

    }
}