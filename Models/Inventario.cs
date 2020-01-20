using System;
using System.Collections.Generic;

namespace pvbackend.Models
{
    public partial class Inventario
    {
        public int Inventarioid { get; set; }
        public int? Articuloid { get; set; }
        public int? Existencia { get; set; }
    }
}
