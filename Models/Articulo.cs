using System;
using System.Collections.Generic;

namespace pvbackend.Models
{
    public partial class Articulo
    {
        public int Articuloid { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public double? Precio { get; set; }
    }
}
