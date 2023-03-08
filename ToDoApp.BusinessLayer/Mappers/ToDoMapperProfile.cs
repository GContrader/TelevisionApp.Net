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

            this.CreateMap<User, UserDTO>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(source => source.Name))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(source => source.Email))
                .ForMember(dto => dto.Indirizzo, opt => opt.MapFrom(source => source.Indirizzo))
                .ForMember(dto => dto.DataNascita, opt => opt.MapFrom(source => source.DataNascita));

            this.CreateMap<Azienda, AziendaDTO>()
               .ForMember(dto => dto.Name, opt => opt.MapFrom(source => source.Name));
        }
    }
}
