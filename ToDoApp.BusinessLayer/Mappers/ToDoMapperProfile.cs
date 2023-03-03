using AutoMapper;
using ToDoApp.BusinessLayer.Models;
using ToDoApp.DataAccessLayer.Entities;

namespace ToDoApp.BusinessLayer.Mappers
{
    public class ToDoMapperProfile: Profile
    {
        public ToDoMapperProfile()
        {
            this.CreateMap<TodoItem, TodoItemDto>()
                .ForMember(dto => dto.Title, opt => opt.MapFrom(source => source.Name))
                .ForMember(dto => dto.LastModified, opt => opt.MapFrom(source => source.LastModified.ToShortDateString()));
        }
    }
}
