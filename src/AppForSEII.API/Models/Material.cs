using DataType = System.ComponentModel.DataAnnotations.DataType;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;
namespace AppForSEII.API.Models;

[Index(nameof(Nombre), IsUnique = true)]
public class Material
{
    public Material()
    {
        this.Nombre = string.Empty;
        this.Piezas3D = new HashSet<Pieza3D>();
    }

    public Material(string nombre, decimal precioPorGramo, decimal stockGramos) : this()
    {
        this.Nombre = nombre;
        this.PrecioPorGramo = precioPorGramo;
        this.StockGramos = stockGramos;
    }
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    [StringLength(50, ErrorMessage = "El nombre debe tener entre 1 y 50 caracteres.", MinimumLength = 1)]
    public string Nombre { get; set; }

    [Display(Name = "Precio por gramo")]
    [DataType(DataType.Currency)]
    [Precision(10, 4)]
    [Range(0.0001, 99999.9999, ErrorMessage = "El precio por gramo debe ser de 0,0001 como mínimo.")]
    public decimal PrecioPorGramo { get; set; }

    [Display(Name = "Stock (g)")]
    [Precision(10,2)]
    [Range(0, 99999.99, ErrorMessage = "El stock no puede ser negativo.")]
    public decimal StockGramos { get; set; }

    public HashSet<Pieza3D> Piezas3D { get; set; }
}