using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.API.Autor.Models;
using TiendaServicios.API.Autor.Persistence;

namespace TiendaServicios.API.Autor.App
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorLibro>
        {
            public string AutorGuid { get; set; } = string.Empty;
        }

        public class Manejeador : IRequestHandler<AutorUnico, AutorLibro>
        {
            public readonly ContextAutor _contexto;

            public Manejeador(ContextAutor contexto)
            {
                _contexto = contexto;
            }

            public async Task<AutorLibro> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _contexto.AutorLibro.Where(x => x.AutorLibroGuid == request.AutorGuid).FirstOrDefaultAsync(cancellationToken);
                
                if (autor == null)
                    throw new Exception("Autor no fue encontrado.");
                
                return autor;
            }
        }
    }
}
