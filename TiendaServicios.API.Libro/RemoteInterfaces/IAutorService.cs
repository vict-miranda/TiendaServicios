using TiendaServicios.API.Libro.RemoteModels;

namespace TiendaServicios.API.Libro.RemoteInterfaces
{
    public interface IAutorService
    {
        Task<(bool resultadoOk, AutorRemote autor, string errorMsg)> GetAutor(Guid id);
    }
}
