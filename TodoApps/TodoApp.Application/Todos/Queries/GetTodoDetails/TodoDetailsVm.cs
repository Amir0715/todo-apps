using AutoMapper;
using TodoApp.Application.Common.Mappings;
using TodoApp.Domain;

namespace TodoApp.Application.Todos.Queries.GetTodoDetails;

public class TodoDetailsVm: IMapWith<Todo>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime EndedAt { get; set; }
    public bool IsDone { get; set; } = false;
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Todo, TodoDetailsVm>()
            .ForMember(todoVm => todoVm.Title,
                opt => opt.MapFrom(todo => todo.Title))
            .ForMember(todoVm => todoVm.Id,
                opt => opt.MapFrom(todo => todo.Id))
            .ForMember(todoVm => todoVm.IsDone,
                opt => opt.MapFrom(todo => todo.IsDone))
            .ForMember(todoVm => todoVm.CreatedAt,
                opt => opt.MapFrom(todo => todo.CreatedAt))
            .ForMember(todoVm => todoVm.Description,
                opt => opt.MapFrom(todo => todo.Description))
            .ForMember(todoVm => todoVm.EndedAt,
                opt => opt.MapFrom(todo => todo.EndedAt));
    }
}