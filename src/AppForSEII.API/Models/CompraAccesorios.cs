namespace AppForSEII.API.Models;


public class CompraAccesorios 
{
    public CompraAccesorios()
    {
    }
    public CompraAccesorios(Cliente cliente, DateTime fechaCompra, string nombreCliente,string apellidoCliente, string direccionEnvio,string numeroTelefono, decimal precioTotal, MetodoPago metodoPago)
    {
        Cliente = cliente;
        FechaCompra = fechaCompra;
        NombreCliente = nombreCliente;
        ApellidoCliente = apellidoCliente;
        DireccionEnvio = direccionEnvio;
        NumeroTelefono = numeroTelefono;
        PrecioTotal = precioTotal;
        MetodoPago = metodoPago;
    }
    public int Id { get; set; }
    
    [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Fecha de Compra")]
    public DateTime FechaCompra { get; set; }

     [StringLength(50, ErrorMessage = "El nombre no puede tener mas de 50 caracteres.")]
    public string NombreCliente { get; set; }

     [StringLength(50, ErrorMessage = "El apellido no puede tener mas de 50 caracteres.")]
    public string ApellidoCliente { get; set; }

     [StringLength(100, ErrorMessage = "La direccion de envio no puede tener mas de 100 caracteres.")]
    public string DireccionEnvio { get; set; }

    [StringLength(50, ErrorMessage = "El numero de telefono no puede tener mas de 50 caracteres.")]
    public string NumeroTelefono { get; set; }

    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
    [Range(0.5, float.MaxValue, ErrorMessage = "Minimum price is 0.5 ")]
    [Display(Name = "Precio Total")]
    [Precision(10, 2)]
    public decimal PrecioTotal { get; set; }
    public MetodoPago MetodoPago { get; set; }
    
    public Cliente Cliente { get; set; }

    public IList<LineasCompraAccesorios> LineasCompraAccesorios { get; set; }


    
}