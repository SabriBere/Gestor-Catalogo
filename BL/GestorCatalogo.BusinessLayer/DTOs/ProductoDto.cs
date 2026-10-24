// - **DTO de respuesta (`ProductoDto`):** 
// los endpoints no deben retornar la entidad directamente, sino este DTO proyectado.

namespace GestorCatalogo.BusinessLayer.DTOs.Response;

public class ProductoDto
{
    public int Id { get; set; } 
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public bool Activo { get; set; }
}
