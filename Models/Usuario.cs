using System;
using System.Collections.Generic;

namespace pvbackend.Models
{
    public partial class Usuario
    {
        public int Usuarioid { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public int? Tipo { get; set; }
    }
}
