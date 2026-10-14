namespace AppForSEII.API.Models;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;
using DataType = System.ComponentModel.DataAnnotations.DataType;

public class CompraModelo3D
{
    public CompraModelo3D(){}

    public CompraModelo3D(Cliente cliente, string nombreCliente, string apellidosCliente, string correoElectronico,
        string direccionFacturacion, MetodoPago metodoPago, string? descripcion, DateTime fechaCompra, IList<LineaCompraModelo> lineasCompra)
    {
        Cliente = cliente;
        NombreCliente = nombreCliente;
        ApellidosCliente = apellidosCliente;
        CorreoElectronico = correoElectronico;
        DireccionFacturacion = direccionFacturacion;
        MetodoPago = metodoPago;
        Descripcion = descripcion;
        LineasCompra = lineasCompra;
        FechaCompra = fechaCompra;
        PrecioTotal = lineasCompra.Sum(l => l.Subtotal);
    }
 
    public int Id { get; set; }
 
    [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime), Display(Name = "Fecha de compra")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime FechaCompra { get; set; }
 
    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    [Display(Name = "Nombre")]
    public string NombreCliente { get; set; }
 
    [StringLength(100, ErrorMessage = "Los apellidos no pueden tener más de 100 caracteres.")]
    [Display(Name = "Apellidos")]
    public string ApellidosCliente { get; set; }
 
    [EmailAddress]
    [StringLength(100, ErrorMessage = "El correo electrónico no puede tener más de 100 caracteres.")]
    [Display(Name = "Correo electrónico")]
    public string CorreoElectronico { get; set; }
 
    [StringLength(200, ErrorMessage = "La dirección de facturación no puede tener más de 200 caracteres.")]
    [Display(Name = "Dirección de facturación")]
    public string DireccionFacturacion { get; set; }
 
    [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres.")]
    [Display(Name = "Descripción")]
    public string? Descripcion { get; set; }
 
    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
    [Display(Name = "Precio total")]
    [Precision(10, 2)]
    public decimal PrecioTotal { get; set; }
 
    [Display(Name = "Método de pago")]
    public MetodoPago MetodoPago { get; set; }
 
    // Relación 1..N con LineaCompraModelo
    public IList<LineaCompraModelo> LineasCompra { get; set; }
 
    // Relación N..1 con Cliente
    // La clave de ApplicationUser (IdentityUser) es string, por eso ClienteId es string.
    // Si se borra un cliente no se borran sus compras.
    public string ClienteId {get; set;}

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Cliente Cliente { get; set; }
}