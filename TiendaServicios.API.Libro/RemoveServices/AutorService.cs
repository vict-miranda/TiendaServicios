using System.Text.Json;
using TiendaServicios.API.Libro.RemoteInterfaces;
using TiendaServicios.API.Libro.RemoteModels;

namespace TiendaServicios.API.Libro.RemoveServices
{
    public class AutorService : IAutorService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        public AutorService(IHttpClientFactory httpClientFactory, ILogger logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool resultadoOk, AutorRemote autor, string errorMsg)> GetAutor(Guid id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Autores");
                var response = await client.GetAsync($"api/Autor/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<AutorRemote>(contenido, options);

                    return (true, resultado, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
    }
}
