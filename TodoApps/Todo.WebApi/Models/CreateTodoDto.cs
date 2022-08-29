using AutoMapper;
using TodoApp.Application.Common.Mappings;
using TodoApp.Application.Todos.Commands.CreateTodo;

namespace TodoApps.Models;

public class CreateTodoDto : IMapWith<CreateTodoCommand>
{
    public string Title { get; set; }
    public DateTime EndedAt { get; set; }
    public bool IsDone { get; set; }
    public string Description { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateTodoDto, CreateTodoCommand>()
            .ForMember(todoCommand => todoCommand.Title,
                opt => opt.MapFrom(todoDto => todoDto.Title))
            .ForMember(todoCommand => todoCommand.Description,
                opt => opt.MapFrom(todoDto => todoDto.Description))
            .ForMember(todoCommand => todoCommand.EndedAt,
                opt => opt.MapFrom(todoDto => todoDto.EndedAt))
            .ForMember(todoCommand => todoCommand.IsDone,
                opt => opt.MapFrom(todoDto => todoDto.IsDone));
    }
}