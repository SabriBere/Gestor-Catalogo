using Microsoft.AspNetCore.Mvc;
using GestorCatalogo.BusinessLayer.DTOs.Response;
using GestorCatalogo.BusinessLayer.DTOs.Request;
using GestorCatalogo.BusinessLayer.Interfaces;

namespace GestorCatalogo.PresentationLayer;

[ApiController]
[Route("api/productos")]
[Tags("Productos")]

public class ProductosController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductosController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    [EndpointSummary("Consultar listado de productos")]

    public IActionResult ObtenerListadoProducto()
    {
        return Ok(_productoService.ObtenerTodos());

    }

    [HttpGet("{id:int}")]
    [EndpointSummary("Consultar un producto especifico por ID")]

    public IActionResult ObtenerProductoId(int id)
    {
        ProductoDto? producto = _productoService.ObtenerPorId(id);

        if(producto is null)
        {
            return NotFound($"No se encontró un producto con el ID {id}");
        }

        return Ok(producto);
    }

    [HttpPost]
    [EndpointSummary("Alta de productos")]

    // usar CrearProductoDto
    public IActionResult CrearProducto([FromBody] CreateProductoDto producto)
    {
        ProductoDto productoCreado = _productoService.CrearProducto(producto);
            return CreatedAtAction(
                nameof(ObtenerProductoId),
                new { id = productoCreado.Id },
                productoCreado
            );
    }

    [HttpPut("{id:int}")]
    [EndpointSummary("Modificar un producto")]

    //usar CrearProductoDto
    public IActionResult ModificarProductos(int id, [FromBody] CreateProductoDto modificarProducto)
    {
        ProductoDto? productoModificado = _productoService.ModificarProducto(id, modificarProducto);

        if(productoModificado is null)
        {
            return NotFound($"No se encontró un producto con el ID {id}");
        }

        return Ok(productoModificado);
    }

    [HttpDelete("{id:int}")]
    [EndpointSummary("Eliminar un producto")]

    // usar CrearProductoDto
    public IActionResult EliminarProductos(int id)
    {
        bool eliminado = _productoService.EliminarProducto(id);

        if (!eliminado)
        {
            return NotFound($"No se encontró un producto con el ID {id}");
        }
        //usar created action con status 204, 404 si no lo encuentra
        return NoContent();
    }


}

