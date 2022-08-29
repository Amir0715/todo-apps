using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Todos.Commands.CreateTodo;
using TodoApp.Application.Todos.Commands.DeleteTodo;
using TodoApp.Application.Todos.Commands.UpdateTodo;
using TodoApp.Application.Todos.Queries.GetTodoDetails;
using TodoApp.Application.Todos.Queries.GetTodoList;
using TodoApps.Models;

namespace TodoApps.Controllers;

[Route("api/[controller]")]
public class TodoController : BaseController
{
    private readonly IMapper _mapper;

    public TodoController(IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<TodoListVm>> GetAll()
    {
        var query = new GetTodoListQuery()
        {
            UserId = UserId
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoDetailsVm>> Get(Guid id)
    {
        var query = new GetTodoDetailsQuery()
        {
            UserId = UserId,
            Id = id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateTodoDto createTodoDto)
    {
        var command = _mapper.Map<CreateTodoCommand>(createTodoDto);
        command.UserId = UserId;
        var todoId = await Mediator.Send(command);
        return Ok(todoId);
    }
    
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateTodoDto updateTodoDto)
    {
        var command = _mapper.Map<UpdateTodoCommand>(updateTodoDto);
        command.UserId = UserId;
        var todoId = await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<TodoDetailsVm>> Delete(Guid id)
    {
        var command = new DeleteTodoCommand()
        {
            UserId = UserId,
            Id = id
        };
        var vm = await Mediator.Send(command);
        return Ok(vm);
    }
}