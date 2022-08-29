using FluentValidation;

namespace TodoApp.Application.Todos.Queries.GetTodoList;

public class GetTodoListQueryValidator: AbstractValidator<GetTodoListQuery>
{
    public GetTodoListQueryValidator()
    {
        RuleFor(todo => todo.UserId).NotEqual(Guid.Empty);
    }
}