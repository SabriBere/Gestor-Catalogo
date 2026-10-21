# Consigna Oficial: Práctico del Bloque 1

## Gestión de Productos en Consola

### Objetivo

Aplicar los fundamentos de Programación Orientada a Objetos (POO), diseño con interfaces, manipulación de listas en memoria (`List<T>`) y consultas con LINQ en una aplicación C# de consola.

### Descripción del problema

Una tienda local necesita un prototipo simple para gestionar sus productos en memoria antes de migrar su sistema a una Web API. Se deberá construir una solución de consola que modele los datos y permita realizar operaciones básicas sobre el catálogo.

### Requerimientos técnicos

#### 1. Modelo de Dominio (`Producto`)

Crear la clase `Producto` con las siguientes propiedades automáticas:

- `Id` (`int`)
- `Nombre` (`string`)
- `Precio` (`decimal`)
- `Categoria` (`string`)
- `Activo` (`bool`)

#### 2. Interfaz de Contrato (`IProductoRepository`)

Definir una interfaz que establezca las operaciones sobre los productos:

```csharp
void Agregar(Producto producto);
List<Producto> ObtenerTodos();
Producto ObtenerPorId(int id);
List<Producto> BuscarPorCategoria(string categoria);
```

#### 3. Implementación en Memoria (`ProductoRepository`)

- Crear una clase que implemente la interfaz `IProductoRepository`.
- Utilizar una `List<Producto>` privada para almacenar los registros de forma temporal.
- Inicializar la lista en el constructor con 3 o 4 productos de prueba por defecto (*seed data*).
- Implementar las búsquedas y los filtrados utilizando métodos de extensión de LINQ (`Where`, `FirstOrDefault`, `ToList`).

#### 4. Ejecución (`Program.cs`)

- Instanciar la clase del repositorio (`IProductoRepository repo = new ProductoRepository();`) en `Program.cs`.
- Probar en la consola:
  - La lista completa de productos.
  - La búsqueda de un producto por su ID.
  - El filtrado de productos por categoría.
  - La incorporación de un nuevo producto usando `Agregar(...)`.

## Entrega

Se entrega como archivo PDF o ZIP, enlace al repositorio, código o texto.

