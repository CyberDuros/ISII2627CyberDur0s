namespace AppForSEII.API.Models;

public class LineaCompraModelo
{
    public LineaCompraModelo(){}

    public LineaCompraModelo(CompraModelo3D compraModelo3D, Modelo3D modelo3D, int cantidadLicencias, decimal precioUnidad)
    {
        CompraModelo3D = compraModelo3D;
        Modelo3D = modelo3D;
        CantidadLicencias = cantidadLicencias;
        PrecioUnidad = precioUnidad;
        Subtotal =  cantidadLicencias * precioUnidad;
    }


    public int Id { get; set; }

    [Display(Name = "Cantidad de licencias")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad minima de licencias es 1")]
    public int CantidadLicencias { get; set; }
    
    [DataType(DataType.Currency)]
    [Display(Name = "Precio por unidad")]
    [Precision(10, 2)]
    public decimal PrecioUnidad { get; set; }
    
    [DataType(DataType.Currency)]
    [Precision(10, 2)]
    public decimal Subtotal { get; set; }

    //Relacion 1..N con CompraModelo3D
    public int CompraModelo3DId { get; set; }
    
    public CompraModelo3D CompraModelo3D { get; set; }

    //Relacion 1..N con Modelo3D
    public int Modelo3DId { get; set; }
    
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Modelo3D Modelo3D { get; set; }
}