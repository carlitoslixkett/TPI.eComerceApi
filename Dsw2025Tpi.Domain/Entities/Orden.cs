using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities
{
    public class Orden
    {
        public int Id { get; set; }
        public string ClienteId { get; set; }
        public string DireccionEnvio { get; set; }
        public string DireccionFacturacion { get; set; }
        public List<DetalleOrden> Detalles { get; set; }
    }
}
