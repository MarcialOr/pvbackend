using System;
using System.Collections.Generic;

namespace pvbackend.Models
{
    public partial class Pedidoencabezado
    {
        public int Pedidoid { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Costo { get; set; }
    }
}
