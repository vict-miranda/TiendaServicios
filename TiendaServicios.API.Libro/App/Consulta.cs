using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Libro.Persistence;
using TiendaServicios.API.Libro.RemoteInterfaces;

namespace TiendaServicios.API.Libro.App
{
    public class Consulta
    {
        public class ListaLibroMaterial : IRequest<List<LibroMaterialDto>>
        {

        }

        public class Manejeador : IRequestHandler<ListaLibroMaterial, List<LibroMaterialDto>>
        {
            public readonly ContextoLibreria _contexto;
            public readonly IMapper _mapper;
            public readonly IAutorService _autorService;

            public Manejeador(ContextoLibreria contexto, IMapper mapper, IAutorService autorService)
            {
                _contexto = contexto;
                _mapper = mapper;
                _autorService = autorService;
            }

            public async Task<List<LibroMaterialDto>> Handle(ListaLibroMaterial request, CancellationToken cancellationToken)
            {
                var data = await _contexto.LibreriaMaterials.ToListAsync(cancellationToken);
                var list = new List<LibroMaterialDto>();

                foreach (var item in data)
                {
                    var response = await _autorService.GetAutor((Guid)item.AutorLibroId);
                    if (response.resultadoOk)
                    {
                        list.Add(new LibroMaterialDto
                        {
                            Autor = response.autor,
                            Titulo = item.Titulo,
                            FechaPublicacion = item.FechaPublicacion,
                            AutorLibroId = item.AutorLibroId,
                            LibreriaMaterialId = item.LibreriaMaterialId
                        });
                    }                    
                }

                return list;
            }
        }
    }
}
