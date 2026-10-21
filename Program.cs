    IProductoRepository productoRepository = new ProductoRepository();

    //Hago un pseudo seed con varios productos
    List<Producto> productos = new()
    {
        new Producto(1, "Teclado", 25000m, "Periféricos", true),
        new Producto(2, "Mouse", 15000m, "Periféricos", true),
        new Producto(3, "Monitor", 250000m, "Pantallas", true),
        new Producto(4, "Notebook", 900000m, "Computadoras", false)
    };

    productoRepository.AgregarVarios(productos);
    var listaProductos = productoRepository.ObtenerTodos();
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
    string? numeroIngresado = Console.ReadLine();

    if (int.TryParse(numeroIngresado, out int idConvertido))
    {
        Producto? productoObtenido = productoRepository.ObtenerPorId(idConvertido);

        if (productoObtenido is not null)
        {
            Console.WriteLine($"ID: {productoObtenido.Id}");
            Console.WriteLine($"Nombre: {productoObtenido.Nombre}");
            Console.WriteLine($"Precio: ${productoObtenido.Precio}");
            Console.WriteLine($"Categoría: {productoObtenido.Categoria}");
            Console.WriteLine($"Activo: {productoObtenido.Activo}");
            Console.WriteLine("--------------------");    
        }
        else
        {
            Console.WriteLine("No existe un producto con ese ID");
        }
    }
    else
    {
        Console.WriteLine("El ID ingresado no es válido");
    }


    //Buscar por categoria
    Console.Write("Ingresar una categoria: ");
    string? nombreCategoria = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(nombreCategoria))
    {

        List<Producto> productoObtenido = productoRepository.BuscarPorCategoria(nombreCategoria);

        if(productoObtenido.Count == 0)
        {
            Console.WriteLine($"No se encontraron productos en la categoría '{nombreCategoria}'");
        }

        productoObtenido.ForEach(producto =>
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
    }
    else
    {
        Console.WriteLine("Debe ingresar una categoria");
    }
