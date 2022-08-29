using MediatR;
using TodoApp.Application.Exceptions;
using TodoApp.Application.Interfaces;
using TodoApp.Domain;

namespace TodoApp.Application.Todos.Commands.DeleteTodo;

public class DeleteTodoCommandHandler
    : IRequestHandler<DeleteTodoCommand>
{
    private readonly ITodosDbContext _dbContext;

    public DeleteTodoCommandHandler(ITodosDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    
    public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Todos.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Todo), request.Id);
        }

        _dbContext.Todos.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}