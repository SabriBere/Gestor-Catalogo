using GestorCatalogo.DataAccessLayer.Models;

namespace GestorCatalogo.DataAccessLayer.Interfaces;
public interface IProductoRepository
{
    Producto Agregar(Producto producto);
    List<Producto> ObtenerTodos();
    Producto? ObtenerPorId(int id);
    Producto? Modificar(int id, Producto producto);

    bool Eliminar(int id);

}
