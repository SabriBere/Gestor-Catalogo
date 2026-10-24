using GestorCatalogo.DataAccessLayer.Models;

namespace GestorCatalogo.DataAccessLayer.Interfaces;
public interface IProductoRepository
{
    void Agregar(Producto producto);
    List<Producto> ObtenerTodos();
    Producto? ObtenerPorId(int id);
    List<Producto> BuscarPorCategoria(string categoria);
}
