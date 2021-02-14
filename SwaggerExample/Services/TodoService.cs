using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SwaggerExample.Helpers;
using SwaggerExample.Interfaces;
using SwaggerExample.Models.DAO;
using SwaggerExample.Models.DTO.Todos;
using SwaggerExample.Models.Enums;

namespace SwaggerExample.Services
{

    public class TodoService : ITodoService
    {
        private readonly DHContext _context;
        private readonly ILogger<TodoService> _logger;

        public TodoService(
            DHContext context,
            ILogger<TodoService> logger
        )
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Todo> ChangeStatusAsync(Guid Id, ETodoStatus Status)
        {

            Todo entity = Get(Id);

            if(entity == null){
                return null;
            }


            entity.Status = Status;

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Todo> CreateAsync(CreateTodo req)
        {
            Todo entity = new Todo();

            PropertyHelper.UpdateProperty(ref entity, req);

            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = entity.CreatedAt;

            _context.Todos.Update(entity);
            await _context.SaveChangesAsync();
            
            return entity;
        }

        public async Task<Todo> DeleteAsync(Guid Id)
        {
            Todo entity = Get(Id);

            if(entity == null){
                return null;
            }

            entity.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return entity;
        }

        public Todo Get(Guid Id)
        {
            Todo entity = _context.Todos
            .Where(e => e.DeletedAt == null)
            .FirstOrDefault(e => e.Id == Id);
            return entity;
        }

        public IQueryable<Todo> List()
        {
            var entities = _context.Todos.Where(e => e.DeletedAt == null);

            return entities;
        }

        public async Task<Todo> UpdateAsync(UpdateTodo req)
        {
            Todo entity = Get(req.Id);

            if(entity == null){
                return null;
            }

            PropertyHelper.UpdateProperty(ref entity, req);

            entity.UpdatedAt = DateTime.Now;

            _context.Todos.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}