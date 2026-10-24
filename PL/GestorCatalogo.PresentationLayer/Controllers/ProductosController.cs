using Microsoft.AspNetCore.Mvc;


namespace GestorCatalogo.PresentationLayer;

[ApiController]
[Route("/api/[controller]/[action]")]
[Tags("Productos")]

public class ProductosController : ControllerBase
{
    // private readonly IProductoService _productoService;

    // public ProdcutoController(IProductoService productoService)
    // {
    //     _productoService = productoService;
    // }

    // [HttpGet("/api/productos")]
    // [EndpointSummary("Consultar listado de productos")]

    //usar CrearProductoDto
    // public async Task<IActionResult> ObtenerListadoProducto()
    // {
        
    //     //usar created action con status 200
    // }

    // [HttpGet("/api/productos/{id:int}")]
    // [EndpointSummary("Consultar un producto especifico por ID")]

    // public async Task<IActionResult> ObtenerProductoId()
    // {
        
    //     //usar created action con status 200 y 404 si no existe
    // }

    // [HttpPost("/api/productos")]
    // [EndpointSummary("Alta de productos")]

    //usar CrearProductoDto
    // public async Task<IActionResult> CrearProductos()
    // {
        
    //     //usar created action con status 201
    // }

    // [HttpPut("/api/productos/{id:int}")]
    // [EndpointSummary("Modificar un producto")]

    //usar CrearProductoDto
    // public async Task<IActionResult> ModificarProductos()
    // {
        
    //     //usar created action con status 200, 404 si no lo encuentra y 400 bad request
    // }

    // [HttpDelete("/api/productos/{id:int}")]
    // [EndpointSummary("Eliminar un producto")]

    //usar CrearProductoDto
    // public async Task<IActionResult> EliminarProductos()
    // {
        
    //     //usar created action con status 204, 404 si no lo encuentra
    // }


}

