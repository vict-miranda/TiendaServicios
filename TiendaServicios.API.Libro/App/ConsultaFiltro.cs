using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Libro.Models;
using TiendaServicios.API.Libro.Persistence;

namespace TiendaServicios.API.Libro.App
{
    public class ConsultaFiltro
    {
        public class LibreriaMaterialUnico : IRequest<LibroMaterialDto>
        {
            public Guid? LibreriaMaterialGuid { get; set; }
        }

        public class Manejeador : IRequestHandler<LibreriaMaterialUnico, LibroMaterialDto>
        {
            public readonly ContextoLibreria _contexto;
            public readonly IMapper _mapper;

            public Manejeador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<LibroMaterialDto> Handle(LibreriaMaterialUnico request, CancellationToken cancellationToken)
            {
                var libreriaMaterial = await _contexto.LibreriaMaterials.Where(x => x.LibreriaMaterialId == request.LibreriaMaterialGuid).FirstOrDefaultAsync(cancellationToken);

                if (libreriaMaterial == null)
                    throw new Exception("Libreria Material no fue encontrada.");

                return _mapper.Map<LibroMaterialDto>(libreriaMaterial);
            }
        }
    }
}
