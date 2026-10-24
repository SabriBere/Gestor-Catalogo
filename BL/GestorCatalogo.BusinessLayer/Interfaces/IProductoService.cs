namespace GestorCatalogo.BusinessLayer.Interfaces;
using GestorCatalogo.BusinessLayer.DTOs.Response;
using GestorCatalogo.BusinessLayer.DTOs.Request;
public interface IProductoService
{
    List<ProductoDto> ObtenerTodos();
    ProductoDto? ObtenerPorId(int id);

    ProductoDto CrearProducto(CreateProductoDto producto);

    ProductoDto? ModificarProducto(int id, CreateProductoDto modificarProducto);

    bool EliminarProducto(int id);
}