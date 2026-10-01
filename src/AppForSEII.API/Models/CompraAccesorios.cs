namespace AppForSEII.API.Models;


public class CompraAccesorios 
{
    public CompraAccesorios()
    {
    }
    public CompraAccesorios(DateTime fechaCompra, string nombreCliente,string apellidoCliente, string direccionEnvio,string numeroTelefono, decimal precioTotal, MetodoPago metodoPago)
    {
        FechaCompra = fechaCompra;
        NombreCliente = nombreCliente;
        ApellidoCliente = apellidoCliente;
        DireccionEnvio = direccionEnvio;
        NumeroTelefono = numeroTelefono;
        PrecioTotal = precioTotal;
        MetodoPago = metodoPago;
    }
    public int Id { get; set; }
    public DateTime FechaCompra { get; set; }
    public string NombreCliente { get; set; }
    public string ApellidoCliente { get; set; }
    public string DireccionEnvio { get; set; }
    public string NumeroTelefono { get; set; }
    public decimal PrecioTotal { get; set; }
    public MetodoPago MetodoPago { get; set; }

    
}