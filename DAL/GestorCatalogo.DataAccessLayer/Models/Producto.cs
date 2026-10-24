namespace GestorCatalogo.DataAccessLayer.Models;

public class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public decimal Precio { get; set; }

    public string Categoria { get; set; }

    public bool Activo { get; set; }

    //constructor
    public Producto(
        int id,
        string nombre,
        decimal precio,
        string categoria,
        bool activo)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
        Categoria = categoria;
        Activo = activo;
    }

}