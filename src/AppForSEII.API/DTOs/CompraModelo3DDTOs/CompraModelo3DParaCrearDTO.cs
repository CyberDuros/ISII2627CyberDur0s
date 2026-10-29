namespace AppForSEII.API.DTOs.CompraModelo3DDTOs;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;
using DataType = System.ComponentModel.DataAnnotations.DataType;

public class CompraModelo3DParaCrearDTO
{
    public CompraModelo3DParaCrearDTO()
    {
        NombreCliente = string.Empty;
        ApellidosCliente = string.Empty;
        CorreoElectronicoCliente = string.Empty;
        DireccionFacturacion = string.Empty;
        LineasCompra = new List<LineaCompraModeloDTO>();
    }

    public CompraModelo3DParaCrearDTO(string nombreCliente, string apellidosCliente, 
                                      string correoElectronicoCliente, string direccionFacturacion, MetodoPago metodoPago, string? descripcion, IList<LineaCompraModeloDTO> lineasCompra)
    {
        NombreCliente = nombreCliente ?? throw new ArgumentNullException(nameof(nombreCliente));
        ApellidosCliente = apellidosCliente ?? throw new ArgumentNullException(nameof(apellidosCliente));
        CorreoElectronicoCliente = correoElectronicoCliente ?? throw new ArgumentNullException(nameof(correoElectronicoCliente));
        DireccionFacturacion = direccionFacturacion;
        MetodoPago = metodoPago;
        Descripcion = descripcion;
        LineasCompra = lineasCompra ?? throw new ArgumentNullException(nameof(lineasCompra));
    }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    [Display(Name = "Nombre")]
    public string NombreCliente { get; set; }

    [Required(ErrorMessage = "Los apellidos son obligatorios")]
    [StringLength(100, ErrorMessage = "Los apellidos no pueden tener más de 100 caracteres.")]
    [Display(Name = "Apellidos")]
    public string ApellidosCliente { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio")]
    [EmailAddress]
    [StringLength(100, ErrorMessage = "El correo electrónico no puede tener más de 100 caracteres.")]
    [Display(Name = "Correo electrónico")]
    public string CorreoElectronicoCliente { get; set; }

    [Required(ErrorMessage = "La dirección de facturación es obligatoria")]
    [StringLength(200, ErrorMessage = "La dirección de facturación no puede tener más de 200 caracteres.")]
    [Display(Name = "Dirección de facturación")]
    public string DireccionFacturacion { get; set; }

    [Required(ErrorMessage = "El método de pago es obligatorio")]
    [Display(Name = "Método de pago")]
    public MetodoPago MetodoPago { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres.")]
    [Display(Name = "Descripción")]
    public string? Descripcion { get; set; }

    public IList<LineaCompraModeloDTO> LineasCompra { get; set; }

    [DataType(DataType.Currency)]
    [Display(Name = "Precio total")]
    public decimal PrecioTotal => LineasCompra.Sum(l => l.Subtotal);

    //Metodo Equals y GetHashCode
    public override bool Equals(object? obj)
    {
        return obj is CompraModelo3DParaCrearDTO dTO &&
               NombreCliente == dTO.NombreCliente &&
               ApellidosCliente == dTO.ApellidosCliente &&
               CorreoElectronicoCliente == dTO.CorreoElectronicoCliente &&
               DireccionFacturacion == dTO.DireccionFacturacion &&
               MetodoPago == dTO.MetodoPago &&
               Descripcion == dTO.Descripcion &&
               LineasCompra.SequenceEqual(dTO.LineasCompra);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(NombreCliente, ApellidosCliente, CorreoElectronicoCliente, DireccionFacturacion, MetodoPago, Descripcion);
    }
}