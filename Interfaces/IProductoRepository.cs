
public interface IProductoRepository
{
    void Agregar(Producto producto);
    void AgregarVarios(List<Producto> productos);
    List<Producto> ObtenerTodos();
    Producto? ObtenerPorId(int id);
    List<Producto> BuscarPorCategoria(string categoria);
}
