using Microsoft.AspNetCore.Mvc;
using Dsw2025Tpi.Data;
using Dsw2025Tpi.Domain.Entities;
using System.Linq;

namespace Dsw2025Tpi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorProductos : ControllerBase
    {
        private readonly Dsw2025TpiContext _contexto;

        public ControladorProductos(Dsw2025TpiContext contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        public IActionResult CrearProducto(Producto producto)
        {
            _contexto.Productos.Add(producto);
            _contexto.SaveChanges();
            return CreatedAtAction(nameof(ObtenerProductoPorId), new { id = producto.Id }, producto);
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var productos = _contexto.Productos.ToList();
            if (!productos.Any())
                return NoContent();

            return Ok(productos);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerProductoPorId(int id)
        {
            var producto = _contexto.Productos.Find(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarProducto(int id, Producto actualizado)
        {
            var producto = _contexto.Productos.Find(id);
            if (producto == null)
                return NotFound();

            producto.CodigoSku = actualizado.CodigoSku;
            producto.Nombre = actualizado.Nombre;
            producto.PrecioUnitarioActual = actualizado.PrecioUnitarioActual;
            producto.CantidadStock = actualizado.CantidadStock;

            _contexto.SaveChanges();
            return Ok(producto);
        }
    }
}
