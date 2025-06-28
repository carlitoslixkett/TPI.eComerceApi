using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string CodigoSku { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitarioActual { get; set; }
        public int CantidadStock { get; set; }
    }
}
