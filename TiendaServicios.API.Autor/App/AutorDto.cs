﻿namespace TiendaServicios.API.Autor.App
{
    public class AutorDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public string AutorLibroGuid { get; set; } = string.Empty;
    }
}
