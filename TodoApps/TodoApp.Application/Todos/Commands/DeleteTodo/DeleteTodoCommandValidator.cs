using FluentValidation;

namespace TodoApp.Application.Todos.Commands.DeleteTodo;

public class DeleteTodoCommandValidator: AbstractValidator<DeleteTodoCommand>
{
    public DeleteTodoCommandValidator()
    {
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}