using DataType = System.ComponentModel.DataAnnotations.DataType;
namespace AppForSEII.API.Models;

[Index(nameof(Nombre), IsUnique = true)]
public class Material
{
     public Material()
    {
    }

    public Material(string nombre, decimal precioPorGramo, decimal stockGramos)
    {
        Nombre = nombre;
        PrecioPorGramo = precioPorGramo;
        StockGramos = stockGramos;
    }
    public int Id { get; set; }

    [StringLength(50, ErrorMessage = "El nombre debe tener entre 1 y 50 caracteres.", MinimumLength = 1)]
    public string Nombre { get; set; } = string.Empty;

    [DataType(DataType.Currency)]
    [Precision(10, 4)]
    [Range(0.0001, 99999.9999, ErrorMessage = "El precio por gramo debe ser de 0,0001 como mínimo.")]
    public decimal PrecioPorGramo { get; set; }

    [Precision(10,2)]
    [Range(0, 99999.99, ErrorMessage = "El stock no puede ser negativo.")]
    public decimal StockGramos { get; set; }

    public HashSet<Pieza3D> Piezas3D { get; set; }
}