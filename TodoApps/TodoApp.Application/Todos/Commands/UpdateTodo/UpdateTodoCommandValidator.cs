using FluentValidation;

namespace TodoApp.Application.Todos.Commands.UpdateTodo;

public class UpdateTodoCommandValidator: AbstractValidator<UpdateTodoCommand>
{
    public UpdateTodoCommandValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
        RuleFor(command => command.Title).NotEmpty().MaximumLength(250);
        RuleFor(command => command.Description).NotEmpty().MaximumLength(1000);
        RuleFor(command => command.EndedAt).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
    }
}