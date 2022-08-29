using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Interfaces;

namespace TodoApp.Application.Todos.Queries.GetTodoList;

public class GetTodoListHandler: IRequestHandler<GetTodoListQuery, TodoListVm>
{
    private readonly ITodosDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTodoListHandler(ITodosDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<TodoListVm> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
    {
        var todosQuery = await _dbContext.Todos.Where(todo => todo.UserId == request.UserId)
            .ProjectTo<TodoLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return new TodoListVm() { Todos = todosQuery };
    }
}