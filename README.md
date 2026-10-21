# Práctico - Gestor de Catálogo en Consola

## Consigna

### Objetivo

Aplicar los fundamentos de Programación Orientada a Objetos (POO), diseño con interfaces, manipulación de listas en memoria (`List<T>`) y consultas con LINQ en una aplicación de consola desarrollada en C#.

### Descripción del problema

Una tienda local necesita un prototipo simple para gestionar sus productos en memoria antes de migrar su sistema a una Web API. Se deberá construir una solución de consola que modele los datos y permita realizar operaciones básicas sobre el catálogo.

### Requerimientos técnicos

#### Modelo de dominio (`Producto`)

Crear la clase `Producto` con las siguientes propiedades automáticas:

- `Id` (`int`)
- `Nombre` (`string`)
- `Precio` (`decimal`)
- `Categoria` (`string`)
- `Activo` (`bool`)

#### Interfaz de contrato (`IProductoRepository`)

Definir una interfaz con los métodos necesarios para operar sobre los productos:

```csharp
void Agregar(Producto producto);
List<Producto> ObtenerTodos();
Producto ObtenerPorId(int id);
List<Producto> BuscarPorCategoria(string categoria);
```

#### Implementación en memoria (`ProductoRepository`)

- Crear una clase que implemente la interfaz `IProductoRepository`.
- Utilizar una colección privada `List<Producto>` para almacenar temporalmente los registros.
- Implementar las búsquedas y los filtros mediante los métodos de extensión de LINQ `Where`, `FirstOrDefault` y `ToList`.

#### Ejecución (`Program.cs`)

- Instanciar directamente la clase del repositorio en `Program.cs`.
- Cargar al menos tres o cuatro productos de prueba al iniciar la aplicación.
- Mostrar en la consola:
  - La lista completa de productos.
  - La búsqueda de un producto por su ID.
  - Los productos filtrados por categoría.

