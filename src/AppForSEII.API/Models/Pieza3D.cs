namespace AppForSEII.API.Models;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;
public class Pieza3D
{
    public Pieza3D()
    {
        this.Nombre = string.Empty;
        this.MaterialesValidos = new HashSet<Material>();
    }

    public Pieza3D(string nombre, decimal peso, CategoriaPieza categoria) : this()
    {
        this.Nombre = nombre;
        this.Peso = peso;
        this.Categoria = categoria;
    }

    public int Id { get; set; }

    [Display(Name = "Nombre")]
    [StringLength(50, ErrorMessage = "El nombre debe tener entre 1 y 50 caracteres.", MinimumLength = 1)]
    public string Nombre { get; set; }

    // Peso en gramos, con dos decimales
    [Display(Name = "Peso (g)")]
    [Precision(8,2)]
    [Range(0.01, 99999.99, ErrorMessage = "El peso debe ser mayor que 0.")]
    public decimal Peso { get; set; }

    [Display(Name = "Categoría")]
    public CategoriaPieza Categoria { get; set; }

    // Relación Pieza3D 0..* ----- 1..* Material
    public HashSet<Material> MaterialesValidos { get; set; }
}