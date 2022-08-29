using FluentValidation;

namespace TodoApp.Application.Todos.Queries.GetTodoDetails;

public class GetTodoDetailsQueryValidator: AbstractValidator<GetTodoDetailsQuery>
{
    public GetTodoDetailsQueryValidator()
    {
        RuleFor(todo => todo.Id).NotEqual(Guid.Empty);
        RuleFor(todo => todo.UserId).NotEqual(Guid.Empty);
    }
}