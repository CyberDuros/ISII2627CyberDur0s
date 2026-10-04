namespace AppForSEII.API.Models;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;

public class LineaCompraAccesorio
{
    public LineaCompraAccesorio()
    {
    }
    public LineaCompraAccesorio(Accesorio accesorio, int cantidad, decimal precioUnidad, decimal subtotal)
    {
        Accesorio = accesorio;
        Cantidad = cantidad;
        PrecioUnidad = precioUnidad;
        Subtotal = subtotal;
    }
    public int Id { get; set; }
    
    public Accesorio Accesorio { get; set; }

    [Display(Name = "Cantidad")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
    public int Cantidad { get; set; }

    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)] 
    [Display(Name = "Precio Unitario")]
    [Precision(10, 2)]
    public decimal PrecioUnidad { get; set; }
    
    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)] 
    [Display(Name = "Subtotal")]
    [Precision(10, 2)]
    public decimal Subtotal { get; set; }
    public CompraAccesorios CompraAccesorios { get; set; }
}
