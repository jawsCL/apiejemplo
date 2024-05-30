using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TuNamespace
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private static List<Producto> productos = new List<Producto>()
        {
            new Producto { Id = 1, Nombre = "Producto 1", Descripcion = "Descripción del Producto 1", Precio = 10.0m, Cantidad = 100 },
            new Producto { Id = 2, Nombre = "Producto 2", Descripcion = "Descripción del Producto 2", Precio = 20.0m, Cantidad = 200 },
            new Producto { Id = 3, Nombre = "Producto 3", Descripcion = "Descripción del Producto 3", Precio = 30.0m, Cantidad = 300 },
            new Producto { Id = 4, Nombre = "Producto 4", Descripcion = "Descripción del Producto 4", Precio = 40.0m, Cantidad = 400 }
        };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Producto>> GetAllProductos()
        {
            if (productos.Count == 0)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Producto> GetProductoById(int id)
        {
            var producto = productos.Find(p => p.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteProducto(int id)
        {
            var index = productos.FindIndex(p => p.Id == id);

            if (index == -1)
            {
                return NotFound();
            }

            productos.RemoveAt(index);
            return Ok();
        }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
