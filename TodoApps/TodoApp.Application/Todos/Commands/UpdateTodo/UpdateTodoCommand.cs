using MediatR;

namespace TodoApp.Application.Todos.Commands.UpdateTodo;

public class UpdateTodoCommand: IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; }
    public DateTime EndedAt { get; set; }
    public string Description { get; set; }
}