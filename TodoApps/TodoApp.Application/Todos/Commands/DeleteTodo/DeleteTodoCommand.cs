using MediatR;

namespace TodoApp.Application.Todos.Commands.DeleteTodo;

public class DeleteTodoCommand: IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}