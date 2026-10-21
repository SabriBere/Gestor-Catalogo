IProductoRepository productoRepository = new ProductoRepository();

// Agregar un producto nuevo.
productoRepository.Agregar(
    new Producto(5, "Auriculares", 30000m, "Periféricos", true)
);

// Mostrar todos los productos.
List<Producto> listaProductos = productoRepository.ObtenerTodos();
listaProductos.ForEach(MostrarProducto);

// Buscar por ID.
Console.Write("Ingresá el ID del producto: ");
string? numeroIngresado = Console.ReadLine();

if (int.TryParse(numeroIngresado, out int idConvertido))
{
    Producto? productoEncontrado = productoRepository.ObtenerPorId(idConvertido);

    if (productoEncontrado is not null)
    {
        MostrarProducto(productoEncontrado);
    }
    else
    {
        Console.WriteLine("No existe un producto con ese ID.");
    }
}
else
{
    Console.WriteLine("El ID ingresado no es válido.");
}

// Buscar por categoría.
Console.Write("Ingresá una categoría: ");
string? nombreCategoria = Console.ReadLine();

if (!string.IsNullOrWhiteSpace(nombreCategoria))
{
    List<Producto> productosEncontrados =
        productoRepository.BuscarPorCategoria(nombreCategoria);

    if (productosEncontrados.Count == 0)
    {
        Console.WriteLine(
            $"No se encontraron productos en la categoría '{nombreCategoria}'."
        );
    }
    else
    {
        productosEncontrados.ForEach(MostrarProducto);
    }
}
else
{
    Console.WriteLine("Debe ingresar una categoría.");
}

static void MostrarProducto(Producto producto)
{
    Console.WriteLine($"ID: {producto.Id}");
    Console.WriteLine($"Nombre: {producto.Nombre}");
    Console.WriteLine($"Precio: ${producto.Precio:N2}");
    Console.WriteLine($"Categoría: {producto.Categoria}");
    Console.WriteLine($"Activo: {producto.Activo}");
    Console.WriteLine("--------------------");
}
