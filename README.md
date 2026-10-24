# Cómo ejecutar la solución

> **Nota para la corrección:** se requiere tener instalado el SDK de **.NET 10**. Los siguientes comandos deben ejecutarse desde la carpeta raíz del repositorio.

Restaurar las dependencias y compilar la solución:

```bash
dotnet restore GestorCatalogo.slnx
dotnet build GestorCatalogo.slnx
```

Iniciar la Web API con el perfil HTTP:

```bash
dotnet run \
  --project PL/GestorCatalogo.PresentationLayer \
  --launch-profile http
```

Cuando la terminal muestre `Now listening on`, abrir manualmente Swagger UI en:

```text
http://localhost:5185/swagger
```

Desde Swagger se pueden probar los endpoints `GET`, `POST`, `PUT` y `DELETE` de `/api/productos`. Los datos se almacenan en memoria y se restablecen al reiniciar la aplicación. Para detenerla, presionar `Ctrl+C` en la terminal.

---

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
