namespace AppForSEII.API.Models;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;

public class LineaCompraAccesorio
{
    public LineaCompraAccesorio()
    {
    }
    public LineaCompraAccesorio(Accesorio accesorio, int cantidad, decimal precioUnitario, decimal subtotal)
    {
        Accesorio = accesorio;
        Cantidad = cantidad;
        PrecioUnitario = precioUnitario;
        Subtotal = subtotal;
    }
    public int Id { get; set; }
    
    public Accesorio Accesorio { get; set; }

    [Display(Name = "Cantidad")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
    public int Cantidad { get; set; }

    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)] 
    [Display(Name = "Precio Unitario")]
    [Precision(5, 2)]
    public decimal PrecioUnitario { get; set; }
    
    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)] 
    [Display(Name = "Subtotal")]
    [Precision(5, 2)]
    public decimal Subtotal { get; set; }
    public IList<CompraAccesorios> ComprasAccesorios { get; set; }
}
