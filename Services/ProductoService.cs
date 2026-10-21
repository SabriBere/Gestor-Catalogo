
public class ProductoService : IProductoService
{
    private readonly List<Producto> _productos = new();

    //colocar metodos con LINQ

    public void Agregar(Producto producto)
    {
        _productos.Add(producto);
    }

    public void AgregarVarios(List<Producto> productos)
    {
        productos.ForEach(producto => _productos.Add(producto));
    }
    public List<Producto> ObtenerTodos()
    {
        return _productos.ToList();
    }
    public Producto? ObtenerPorId(int id)
    {
         //manejo de errores para el id, sino existe
        return _productos.FirstOrDefault(producto => producto.Id == id);
    }
    public List<Producto> BuscarPorCategoria(string categoria)
    {
        //manejo de errores para la categoria, sino existe
        return _productos.Where(producto => producto.Categoria == categoria).ToList();
    }
}