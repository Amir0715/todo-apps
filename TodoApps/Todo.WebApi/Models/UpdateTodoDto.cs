using AutoMapper;
using TodoApp.Application.Common.Mappings;
using TodoApp.Application.Todos.Commands.UpdateTodo;

namespace TodoApps.Models;

public class UpdateTodoDto : IMapWith<UpdateTodoCommand>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; }
    public DateTime EndedAt { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateTodoDto, UpdateTodoCommand>()
            .ForMember(todoCommand => todoCommand.Id,
                opt => opt.MapFrom(todoDto => todoDto.Id))
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