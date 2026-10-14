namespace AppForSEII.API.Models;

using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;
using DataType = System.ComponentModel.DataAnnotations.DataType;

public class ReservaImpresora
{
    public ReservaImpresora()
    {
        NombreCliente = string.Empty;
        ApellidosCliente = string.Empty;
        DireccionFacturacion = string.Empty;
        LineasReserva = new List<LineaReserva>();
        Cliente = new Cliente();
    }

    public ReservaImpresora(string nombreCliente, DateTime fechaReserva, string apellidosCliente, string direccionFacturacion, decimal precioTotal, MetodoPago metodoPago, Cliente cliente): this()
    {
        NombreCliente = nombreCliente;
        FechaReserva = fechaReserva;
        ApellidosCliente = apellidosCliente;
        DireccionFacturacion = direccionFacturacion;
        PrecioTotal = precioTotal;
        MetodoPago = metodoPago;
        Cliente = cliente;
    }

    public int Id { get; set; }

    [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Fecha de Reserva")]
    public DateTime FechaReserva { get; set; }


    [StringLength(50, ErrorMessage = "El nombre del cliente no puede tener más de 50 caracteres.")]
    public string NombreCliente { get; set; }

    [StringLength(50, ErrorMessage = "El apellido del cliente no puede tener más de 50 caracteres.")]
    public string ApellidosCliente { get; set; }

    [StringLength(50, ErrorMessage = "La dirección de facturación no puede tener más de 50 caracteres.")]
    public string DireccionFacturacion { get; set; }

    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
    [Range(0.5, float.MaxValue, ErrorMessage = "El precio total debe ser mayor que 0.5.")]
    [Display(Name = "Precio Total")]
    [Precision(10, 2)]
    public decimal PrecioTotal { get; set; }


    public MetodoPago MetodoPago { get; set; }


    public Cliente Cliente { get; set; }
    public IList<LineaReserva> LineasReserva { get; set; }



}


