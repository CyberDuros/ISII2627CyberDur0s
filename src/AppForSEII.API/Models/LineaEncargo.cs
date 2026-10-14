namespace AppForSEII.API.Models;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;
public class LineaEncargo
{
    public LineaEncargo()
    {
    }

    public LineaEncargo(int cantidad, decimal precioUnidad, 
        EncargoImpresion encargoImpresion, Pieza3D pieza3D, Material material)
    {
        Cantidad = cantidad;
        PrecioUnidad = precioUnidad;
        Subtotal = cantidad * precioUnidad;
        EncargoImpresion = encargoImpresion;
        Pieza3D = pieza3D;
        Material = material;
    }
    public int Id { get; set; }

    [Display(Name = "Cantidad")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad mínima es 1.")]
    public int Cantidad { get; set; }

    [Display(Name = "Precio por unidad")]
    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
    [Precision(10,2)]
    [Range(0, 99999.99, ErrorMessage = "El precio por unidad no puede ser negativo.")]
    public decimal PrecioUnidad { get; set; }

    [Display(Name = "Subtotal")]
    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
    [Precision(10, 2)]
    [Range(0, 99999.99, ErrorMessage = "El subtotal no puede ser negativo.")]
    public decimal Subtotal { get; set; }

    // Relación con EncargoImpresión 1 <>-- 1..* LineaEncargo ("contiene").
    // Si se borran el encargo se borran las líneas.
    public EncargoImpresion EncargoImpresion { get; set; } = null!;

    // Relación LineaEncargo 0..* ---> Pieza3D ("pieza")
    // Si se borra una pieza, las líneas de los encargos ya hecho no se borran
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Pieza3D Pieza3D { get; set; } = null!;
    
    // Relación LineaEncargo 0..* ----> 1 Material ("material seleccionado")
    // Si se borra un material, las líneas de encargos ya hechos no se borran
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Material Material { get; set; } = null!; 
}