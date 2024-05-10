using AutoMapper;
using TiendaServicios.api.Author.Models;

namespace TiendaServicios.api.Author.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AutorLibro, AutorDto>().ReverseMap();
        }
    }
}
