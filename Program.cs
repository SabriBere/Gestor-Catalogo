IProductoService productoService = new ProductoService();

//Hago un pseudo seed con varios productos
List<Producto> productos = new()
{
    new Producto(1, "Teclado", 25000m, "Periféricos", true),
    new Producto(2, "Mouse", 15000m, "Periféricos", true),
    new Producto(3, "Monitor", 250000m, "Pantallas", true),
    new Producto(4, "Notebook", 900000m, "Computadoras", false)
};

productoService.AgregarVarios(productos);
var listaProductos = productoService.ObtenerTodos();
listaProductos.ForEach(producto =>
    {
        {
        Console.WriteLine($"ID: {producto.Id}");
        Console.WriteLine($"Nombre: {producto.Nombre}");
        Console.WriteLine($"Precio: ${producto.Precio}");
        Console.WriteLine($"Categoría: {producto.Categoria}");
        Console.WriteLine($"Activo: {producto.Activo}");
        Console.WriteLine("--------------------");
    }
});

Console.WriteLine(listaProductos);

//Buscar por ID pide ingresar valor
Console.Write("Ingresa el ID del producto: ");
string? numeroIngreado = Console.ReadLine();

//convertir string de la command line
// productoService.ObtenerPorId(numeroIngreado)

//Buscar por categoria
Console.Write("Ingresar una categoria ");
string? nombreCategoria = Console.ReadLine();
