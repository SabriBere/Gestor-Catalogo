// - **DTO de creación/edición (`CreateProductoDto`):**
//   - `Nombre`: requerido (`[Required]`), entre 3 y 100 caracteres (`[StringLength]`).
//   - `Precio`: requerido (`[Required]`), mayor a 0 (`[Range]`).
//   - `Categoria`: requerida (`[Required]`).
using System.ComponentModel.DataAnnotations;
namespace GestorCatalogo.BusinessLayer.DTOs.Request;

public class CreateProductoDto
{
    [Required, StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; } = string.Empty;

    [Required, Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
    public decimal Precio { get; set; }

    [Required]
    public string Categoria { get; set; } = string.Empty;

    public bool Activo { get; set; } //se crea por default como Activo = true;
}
