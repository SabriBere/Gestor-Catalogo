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

# Consigna Oficial: Práctico del Bloque 2

## Web API RESTful de Gestión de Productos en 3 Capas

### Objetivo

Estructurar y desarrollar una Web API RESTful completa en .NET aplicando arquitectura en 3 capas (`Controller` → `Service` → `Repository`), transferencia de datos mediante DTOs, validaciones de entrada con Data Annotations y respuestas HTTP estandarizadas utilizando `IActionResult`.

---

### Descripción del problema

El prototipo de consola desarrollado en el Bloque 1 necesita evolucionar a una API RESTful profesional. Se deberá migrar la lógica a una Web API en .NET utilizando datos en memoria y garantizando una clara separación de responsabilidades entre capas.

---

### Requerimientos técnicos

#### 1. Estructura en 3 capas

- **Presentation Layer (Controllers):** `ProductosController` expone los endpoints HTTP y retorna `IActionResult` (`Ok`, `CreatedAtAction`, `BadRequest`, `NotFound`, `NoContent`).
- **Business Layer (Services):** `IProductoService` y `ProductoService` procesan la lógica del negocio y transforman entre entidades y DTOs.
- **Data Access Layer (Repositories):** `IProductoRepository` y `ProductoRepositoryInMemory` manejan la `List<Producto>` privada en memoria.

#### 2. Modelos y DTOs

- **Entidad de dominio:** `Producto` (`Id`, `Nombre`, `Precio`, `Categoria`, `Activo`).
- **DTO de creación/edición (`CreateProductoDto`):**
  - `Nombre`: requerido (`[Required]`), entre 3 y 100 caracteres (`[StringLength]`).
  - `Precio`: requerido (`[Required]`), mayor a 0 (`[Range]`).
  - `Categoria`: requerida (`[Required]`).
- **DTO de respuesta (`ProductoDto`):** los endpoints no deben retornar la entidad directamente, sino este DTO proyectado.

#### 3. Endpoints del controlador (`/api/productos`)

- `GET /api/productos`: retorna `200 OK` con la lista de `ProductoDto`.
- `GET /api/productos/{id}`: retorna `200 OK` con el `ProductoDto` o `404 Not Found` si no existe.
- `POST /api/productos`: recibe `CreateProductoDto` por el cuerpo de la solicitud, valida las Data Annotations, crea el producto y retorna `201 Created` con `CreatedAtAction`.
- `PUT /api/productos/{id}`: actualiza un producto existente o retorna `404 Not Found`/`400 Bad Request`.
- `DELETE /api/productos/{id}`: elimina el producto por ID y retorna `204 No Content` o `404 Not Found`.

#### 4. Inyección de dependencias (`Program.cs`)

- Registrar los servicios e interfaces en el contenedor de .NET con sus correspondientes ciclos de vida:
  - `AddScoped` para el servicio.
  - `AddScoped` para el repositorio.

### Ejecución Práctico del Bloque 2

<!-- Branch -->