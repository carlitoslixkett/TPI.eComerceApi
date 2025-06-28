using Microsoft.AspNetCore.Mvc;
using Dsw2025Tpi.Data;
using Dsw2025Tpi.Domain.Entities;
using System.Linq;

namespace Dsw2025Tpi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorOrdenes : ControllerBase
    {
        private readonly Dsw2025TpiContext _contexto;

        public ControladorOrdenes(Dsw2025TpiContext contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        public IActionResult CrearOrden(Orden orden)
        {
            var idsProductos = orden.Detalles.Select(d => d.ProductoId).ToList();
            var productos = _contexto.Productos.Where(p => idsProductos.Contains(p.Id)).ToList();

            foreach (var detalle in orden.Detalles)
            {
                var producto = productos.FirstOrDefault(p => p.Id == detalle.ProductoId);
                if (producto == null || producto.CantidadStock < detalle.Cantidad)
                {
                    return BadRequest("Stock insuficiente o producto no encontrado");
                }

                producto.CantidadStock -= detalle.Cantidad;
                detalle.PrecioUnitario = producto.PrecioUnitarioActual;
            }

            _contexto.Ordenes.Add(orden);
            _contexto.SaveChanges();
            return CreatedAtAction(nameof(CrearOrden), new { id = orden.Id }, orden);
        }
    }
}
