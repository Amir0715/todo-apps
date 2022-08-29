using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Exceptions;
using TodoApp.Application.Interfaces;
using TodoApp.Domain;

namespace TodoApp.Application.Todos.Commands.UpdateTodo;

public class UpdateTodoCommandHandler: IRequestHandler<UpdateTodoCommand>
{
    private readonly ITodosDbContext _dbContext;

    public UpdateTodoCommandHandler(ITodosDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    
    public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Todos.FirstOrDefaultAsync(
            todo => todo.Id == request.Id, cancellationToken);
        
        if (entity == null || entity.UserId != request.UserId)
            throw new NotFoundException(nameof(Todo), request.Id);

        entity.Title = request.Title;
        entity.EndedAt = request.EndedAt;
        entity.IsDone = request.IsDone;
        entity.Description = request.Description;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}