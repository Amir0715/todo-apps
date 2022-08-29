using FluentValidation;

namespace TodoApp.Application.Todos.Commands.CreateTodo;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(command => command.Title).NotEmpty().MaximumLength(250);
        RuleFor(command => command.Description).NotEmpty().MaximumLength(1000);
        RuleFor(command => command.EndedAt).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}