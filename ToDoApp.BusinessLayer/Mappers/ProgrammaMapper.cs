using AutoMapper;
using ToDoApp.BusinessLayer.Models;
using ToDoApp.DataAccessLayer.Entities;

namespace ToDoApp.BusinessLayer.Mappers
{
    public class ProgrammaMapper : Profile
    {
        public ProgrammaMapper()
        {
            this.CreateMap<Programma, ProgrammaDTO>().ReverseMap();
                
        }
    }
}
