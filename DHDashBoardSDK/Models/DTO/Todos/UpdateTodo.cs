using System;
using System.ComponentModel.DataAnnotations;
using DHDashBoardSDK.Models.Enums;

namespace DHDashBoardSDK.Models.DTO.Todos
{

    public class UpdateTodo : CreateTodo
    {

        public UpdateTodo(Guid id, string title, string content, ETodoStatus? status)
        {
            Id = id;
            Title = title;
            Content = content;
            Status = status;
        }

        [Key]
        public Guid Id { get; set; }
    }
}