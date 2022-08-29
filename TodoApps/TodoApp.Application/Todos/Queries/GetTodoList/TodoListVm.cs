using MediatR;

namespace TodoApp.Application.Todos.Queries.GetTodoList;

public class TodoListVm
{
    public IList<TodoLookupDto> Todos { get; set; } 
}