using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Autor.Models;
using TiendaServicios.API.Autor.Persistence;

namespace TiendaServicios.API.Autor.App
{
    public class Consulta
    {
        public class ListaAutor : IRequest<List<AutorLibro>>
        {

        }

        public class Manejeador : IRequestHandler<ListaAutor, List<AutorLibro>>
        {
            public readonly ContextAutor _contexto;

            public Manejeador(ContextAutor contexto)
            {
                _contexto = contexto;
            }

            public async Task<List<AutorLibro>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                return await _contexto.AutorLibro.ToListAsync(cancellationToken);
            }
        }
    }
}
