using AutoMapper;
using TiendaServicios.API.Libro.Models;

namespace TiendaServicios.API.Libro.App
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDto>();
        }
    }
}
