﻿using TiendaServicios.api.Author.Models;

namespace TiendaServicios.api.Author.Application
{
    public class AutorDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public string AutorLibroGuid { get; set; }
    }
}
