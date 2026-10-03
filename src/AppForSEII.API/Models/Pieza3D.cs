namespace AppForSEII.API.Models;

public class Pieza3D
{
    public int Id { get; set; }

    [StringLength(50, ErrorMessage = "El nombre debe tener entre 1 y 50 caracteres.", MinimumLength = 1)]
    public string Nombre { get; set; }

    // Peso en gramos, con dos decimales
    [Precision(8,2)]
    [Range(0.01, 99999.99, ErrorMessage = "El peso debe ser mayor que 0.")]
    public decimal Peso { get; set; }

    public CategoriaPieza Categoria { get; set; }

    // Relación Pieza3D 0..* ----- 1..* Material
    public HashSet<Material> MaterialesValidos { get; set; } = new HashSet<Material>();

    public Pieza3D()
    {
    }

    public Pieza3D(string nombre, decimal peso, CategoriaPieza categoria)
    {
        Nombre = nombre;
        Peso = peso;
        Categoria = categoria;
    }
}