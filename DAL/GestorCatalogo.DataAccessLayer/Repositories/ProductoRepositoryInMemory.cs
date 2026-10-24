using System.Globalization;
using GestorCatalogo.DataAccessLayer.Interfaces;
using GestorCatalogo.DataAccessLayer.Models;

namespace GestorCatalogo.DataAccessLayer.Repositories;

using System.Globalization;

public class ProductoRepositoryInMemory : IProductoRepository
{
    private readonly List<Producto> _productos;

    public ProductoRepositoryInMemory()
    {
        _productos = new List<Producto>
        {
            new Producto(1, "Teclado", 25000m, "Periféricos", true),
            new Producto(2, "Mouse", 15000m, "Periféricos", true),
            new Producto(3, "Monitor", 250000m, "Pantallas", true),
            new Producto(4, "Notebook", 900000m, "Computadoras", false)
        };
    }

    public void Agregar(Producto producto)
    {
        _productos.Add(producto);
    }

    public List<Producto> ObtenerTodos()
    {
        return _productos.ToList();
    }
    public Producto? ObtenerPorId(int id)
    {
        return _productos.FirstOrDefault(producto => producto.Id == id);
    }
    public List<Producto> BuscarPorCategoria(string categoria)
    {
        CompareInfo comparador = CultureInfo.GetCultureInfo("es-AR").CompareInfo;

        return _productos
            .Where(producto => comparador.Compare(
                producto.Categoria.Trim(),
                categoria.Trim(),
                CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace
            ) == 0)
            .ToList();
    }
}
