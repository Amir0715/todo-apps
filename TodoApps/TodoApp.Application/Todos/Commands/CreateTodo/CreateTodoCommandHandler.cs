using MediatR;
using TodoApp.Application.Interfaces;
using TodoApp.Domain;

namespace TodoApp.Application.Todos.Commands.CreateTodo;

public class CreateTodoCommandHandler: IRequestHandler<CreateTodoCommand, Guid>
{
    private readonly ITodosDbContext _dbContext;

    public CreateTodoCommandHandler(ITodosDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Guid> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Todo()
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Title = request.Title,
            IsDone = request.IsDone,
            EndedAt = request.EndedAt,
            Description = request.Description
        };
        
        await _dbContext.Todos.AddAsync(todo, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return todo.Id;
    }
}