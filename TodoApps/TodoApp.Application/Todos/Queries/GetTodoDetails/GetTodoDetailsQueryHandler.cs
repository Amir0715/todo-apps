using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Exceptions;
using TodoApp.Application.Interfaces;
using TodoApp.Domain;

namespace TodoApp.Application.Todos.Queries.GetTodoDetails;

public class GetTodoDetailsQueryHandler: IRequestHandler<GetTodoDetailsQuery, TodoDetailsVm>
{
    private readonly ITodosDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTodoDetailsQueryHandler(ITodosDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<TodoDetailsVm> Handle(GetTodoDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Todos.FirstOrDefaultAsync(todo => todo.Id == request.Id, cancellationToken);
        
        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Todo), request.Id);
        }

        return _mapper.Map<TodoDetailsVm>(entity);
    }
}