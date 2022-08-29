using MediatR;

namespace TodoApp.Application.Todos.Commands.CreateTodo;

public class CreateTodoCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public DateTime EndedAt { get; set; }
    public bool IsDone { get; set; }
    public string Description { get; set; }
}