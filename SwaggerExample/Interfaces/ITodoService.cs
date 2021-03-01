using System.Linq;

using System;
using System.Threading.Tasks;
using SwaggerExample.Models.DAO;
using DHDashBoardSDK.Models.DTO.Todos;
using DHDashBoardSDK.Models.Enums;

namespace SwaggerExample.Interfaces
{

    public interface ITodoService
    {

        

        Todo Get(Guid Id);

        IQueryable<Todo> List();

        Task<Todo> CreateAsync(CreateTodo req);

        Task<Todo> UpdateAsync(UpdateTodo req);

        Task<Todo> DeleteAsync(Guid Id);

        Task<Todo> ChangeStatusAsync(Guid Id , ETodoStatus Status);
    }
}