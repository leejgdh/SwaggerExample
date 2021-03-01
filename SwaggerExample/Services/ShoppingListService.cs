using System.Xml;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SwaggerExample.CustomExceptions;
using SwaggerExample.Helpers;
using SwaggerExample.Interfaces;
using SwaggerExample.Models.DAO;
using DHDashBoardSDK.Models.DTO.ShoppingLists;

namespace SwaggerExample.Services
{

    public class ShoppingListService : IShoppingListService
    {
        private readonly DHContext _context;
        private readonly ILogger<ShoppingListService> _logger;


        public ShoppingListService(
            DHContext context,
            ILogger<ShoppingListService> logger
            )
        {
            _context = context;
            _logger = logger;
        }

        public IQueryable<Shop> GetShops(){

            var entities = _context.Shops;

            return entities;
        }

        public Shop GetShop(Guid ShopId)
        {

            var entity = _context.Shops.Where(e => e.DeletedAt == null)
            .FirstOrDefault();

            return entity;
        }

        public async Task<Shop> CreateShopAsync(CreateShop req)
        {
            Shop entity = new Shop();

            PropertyHelper.UpdateProperty(ref entity, req);

            _context.Shops.Update(entity);

            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = entity.CreatedAt;

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Shop> UpdateShopAsync(UpdateShop req)
        {
            Shop entity = GetShop(req.Id);

            if (entity == null)
            {
                throw new ContentNotFoundException("Shop Cannot found");
            }

            PropertyHelper.UpdateProperty(ref entity, req);

            _context.Shops.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }


        public async void DeleteShop(Guid ShopId)
        {
            Shop entity = GetShop(ShopId);

            if(entity == null){
                throw new ContentNotFoundException("Shop Cannot found");
            }

            _context.Shops.Remove(entity);

            await _context.SaveChangesAsync();
        }


        public IQueryable<Product> GetProducts(){
            var entities = _context.Products;

            return entities;
        }

        public Product GetProduct(Guid ProductId)
        {

            var entity = _context.Products.Where(e => e.DeletedAt == null)
            .FirstOrDefault();

            return entity;
        }

        public async Task<Product> CreateProductAsync(CreateProduct req)
        {
            Product entity = new Product();

            PropertyHelper.UpdateProperty(ref entity, req);

            _context.Products.Update(entity);


            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = entity.CreatedAt;

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Product> UpdateProductAsync(UpdateProduct req)
        {

            Product entity = GetProduct(req.Id);

            PropertyHelper.UpdateProperty(ref entity, req);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async void DeleteProduct(Guid ProductId)
        {

            Product entity = GetProduct(ProductId);

            if(entity == null){
                throw new ContentNotFoundException("Product Cannot found");
            }

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }


        public async void AppendShoppingHistory(AppendShoppingHistory req)
        {

            ShoppingHistory entity = new ShoppingHistory();

            PropertyHelper.UpdateProperty(ref entity, req);

            _context.ShoppingHistories.Add(entity);

            await _context.SaveChangesAsync();
        }


    }
}