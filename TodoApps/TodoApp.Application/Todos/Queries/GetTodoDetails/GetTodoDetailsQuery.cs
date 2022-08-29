using MediatR;

namespace TodoApp.Application.Todos.Queries.GetTodoDetails;

public class GetTodoDetailsQuery : IRequest<TodoDetailsVm>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}