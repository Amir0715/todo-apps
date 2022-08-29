using AutoMapper;
using TodoApp.Application.Common.Mappings;
using TodoApp.Domain;

namespace TodoApp.Application.Todos.Queries.GetTodoList;

public class TodoLookupDto: IMapWith<Todo>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Todo, TodoLookupDto>()
            .ForMember(todoDto => todoDto.Id, 
                opt => opt.MapFrom(todo => todo.Id))
            .ForMember(todoDto => todoDto.Title, 
                opt => opt.MapFrom(todo => todo.Title))
            .ForMember(todoDto => todoDto.IsDone, 
                opt => opt.MapFrom(todo => todo.IsDone));
    }
}