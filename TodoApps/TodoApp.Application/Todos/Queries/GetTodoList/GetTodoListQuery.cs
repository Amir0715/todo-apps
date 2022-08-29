using MediatR;

namespace TodoApp.Application.Todos.Queries.GetTodoList;

public class GetTodoListQuery: IRequest<TodoListVm>
{
    public Guid UserId { get; set; }
}