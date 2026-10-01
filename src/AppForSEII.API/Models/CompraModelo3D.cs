namespace AppForSEII.API.Models

public class CompraModelo3D
{
    public CompraModelo3D(){}

    public CompraModelo3D(DateTime fechaCompra, string nombreCliente, string apellidosCliente, 
    string correoEletronico, string direccionFacturacion, string? descripcion, decimal precioTotal, 
    MetodoPago metodoPago)
    {
        FechaCompra = fechaCompra;
        NombreCliente = nombreCliente;
        ApellidosCliente = apellidosCliente;
        CorreoEletronico = correoEletronico;
        DireccionFacturacion = direccionFacturacion;
        Descripcion = descripcion;
        PrecioTotal = precioTotal;
        MetodoPago = metodoPago;
    }

    public int Id { get; set; }
    public DateTime FechaCompra { get; set; }
    public string NombreCliente { get; set; }
    public string ApellidosCliente { get; set; }
    public string CorreoEletronico { get; set; }
    public string DireccionFacturacion { get; set; }
    public string? Descripcion { get; set; }
    public decimal PrecioTotal { get; set; }
    public MetodoPago MetodoPago { get; set; }
}