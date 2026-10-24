using GestorCatalogo.BusinessLayer.DTOs.Response;
using GestorCatalogo.BusinessLayer.DTOs.Request;
using GestorCatalogo.DataAccessLayer.Models;
using GestorCatalogo.DataAccessLayer.Interfaces;
using GestorCatalogo.BusinessLayer.Interfaces;

namespace GestorCatalogo.BusinessLayer.Services;
public class ProductoService: IProductoService
{
    private readonly IProductoRepository _productoRepository;

    public ProductoService(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public List<ProductoDto> ObtenerTodos()
    {
        return _productoRepository
            .ObtenerTodos()
            .Select(producto => new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Categoria = producto.Categoria,
                Activo = producto.Activo
            })
            .ToList();
    }

    public ProductoDto? ObtenerPorId(int id)
    {
        Producto? producto = _productoRepository.ObtenerPorId(id);

        if(producto is null)
        {
            return null;
        }

        return new ProductoDto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Categoria = producto.Categoria,
                    Activo = producto.Activo
                };
    }

    public ProductoDto CrearProducto(CreateProductoDto crearProducto)
    {   Producto producto = new Producto(
                id: 0,
                nombre: crearProducto.Nombre,
                precio: crearProducto.Precio,
                categoria: crearProducto.Categoria,
                activo: true
            );
        Producto productoCreado = _productoRepository.Agregar(producto);

        return new ProductoDto
        {
            Id = productoCreado.Id,
            Nombre = productoCreado.Nombre,
            Precio = productoCreado.Precio,
            Categoria = productoCreado.Categoria,
            Activo = productoCreado.Activo
        };
    }

    public ProductoDto? ModificarProducto(int id, CreateProductoDto modificarProducto)
    {
        Producto? productoExiste = _productoRepository.ObtenerPorId(id);

        if (productoExiste is null)
        {
            return null;
        }

        Producto productoModificado = new Producto(
            id: id,
            nombre: modificarProducto.Nombre,
            precio: modificarProducto.Precio,
            categoria: modificarProducto.Categoria,
            activo: modificarProducto.Activo
        );

        Producto? resultado = _productoRepository.Modificar(id, productoModificado);

        if(resultado is null)
        {
            return null;
        }

        return new ProductoDto
        {
            Id = resultado.Id,
            Nombre = resultado.Nombre,
            Precio = resultado.Precio,
            Categoria = resultado.Categoria,
            Activo = resultado.Activo
        };
    }

    public bool EliminarProducto(int id)
    {
        return _productoRepository.Eliminar(id);
    }
}