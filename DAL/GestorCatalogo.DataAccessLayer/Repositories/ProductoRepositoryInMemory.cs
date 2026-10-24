using System.Globalization;
using GestorCatalogo.DataAccessLayer.Interfaces;
using GestorCatalogo.DataAccessLayer.Models;

namespace GestorCatalogo.DataAccessLayer.Repositories;

using System.Globalization;

public class ProductoRepositoryInMemory : IProductoRepository
{
    private static readonly List<Producto> _productos = new()
    {
        new Producto(1, "Teclado", 25000m, "Periféricos", true),
        new Producto(2, "Mouse", 15000m, "Periféricos", true),
        new Producto(3, "Monitor", 250000m, "Pantallas", true),
        new Producto(4, "Notebook", 900000m, "Computadoras", false)
    };

    public Producto Agregar(Producto producto)
    {
        producto.Id = _productos.Count > 0
        ? _productos.Max(p => p.Id) + 1
        : 1;

        _productos.Add(producto);

        return producto;
    }

    public List<Producto> ObtenerTodos()
    {
        return _productos.ToList();
    }
    public Producto? ObtenerPorId(int id)
    {
        return _productos.FirstOrDefault(producto => producto.Id == id);
    }

    public Producto? Modificar(int id, Producto producto)
    {
        Producto? productoExiste = _productos.FirstOrDefault(producto => producto.Id == id);

        if(productoExiste is null)
        {
            return null;
        }

        productoExiste.Nombre = producto.Nombre;
        productoExiste.Precio = producto.Precio;
        productoExiste.Categoria = producto.Categoria;
        productoExiste.Activo = producto.Activo;

        return productoExiste;
    }

    public bool Eliminar(int id)
    {
        Producto? productoExiste = _productos.FirstOrDefault(producto => producto.Id == id);

        if(productoExiste is null)
        {
            return false;
        }

        return _productos.Remove(productoExiste);
    }
}
