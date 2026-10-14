using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;

namespace AppForSEII.API.Models;

public class EncargoImpresion
{
      public EncargoImpresion()
    {
    }

    public EncargoImpresion(DateTime fechaEncargo, string nombreCliente, string apellidosCliente, 
        string direccionEnvio, string numeroTelefono, string? descripcion,
        decimal precioTotal, MetodoPago metodoPago, Cliente cliente)
    {
        FechaEncargo = fechaEncargo;
        NombreCliente = nombreCliente;
        ApellidosCliente = apellidosCliente;
        DireccionEnvio = direccionEnvio;
        NumeroTelefono = numeroTelefono;
        Descripcion = descripcion;
        PrecioTotal = precioTotal;
        MetodoPago = metodoPago;
        Cliente = cliente;
    }
    public int Id { get; set; }

    [Display(Name = "Fecha del Encargo")]
    [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
    public DateTime FechaEncargo { get; set; }

    [Display(Name = "Nombre")]
    [StringLength(50, ErrorMessage = "El nombre debe tener entre 1 y 50 caracteres.", MinimumLength = 1)]
    public string NombreCliente { get; set; } = String.Empty;

    [Display(Name = "Apellidos")]
    [StringLength(80, ErrorMessage = "Los apellidos deben tener entre 1 y 80 caracteres.", MinimumLength = 1)]
    public string ApellidosCliente { get; set; } = String.Empty;

    [Display(Name = "Dirección de Envío")]
    [StringLength(100, ErrorMessage = "La dirección de envío debe tener 1 y 100 caracteres.", MinimumLength = 1)]
    public string DireccionEnvio { get; set; } = String.Empty;

    [Display(Name = "Número de Teléfono")]
    [Phone]
    public string NumeroTelefono { get; set; } = String.Empty;

    [Display(Name = "Descripción")]
    [StringLength(200, ErrorMessage = "La descripción no puede superar los 200 caracteres")]
    public string? Descripcion { get; set; }

    [Display(Name = "Precio total")]
    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
    [Precision(10, 2)]
    [Range(0, 99999.99, ErrorMessage = "El precio total no puede ser negativo.")]
    public decimal PrecioTotal { get; set; }

    [Display(Name = "Método de pago")]
    public MetodoPago MetodoPago { get; set; }

    // Relación EncargoImpresión 0..* ---- 1 Cliente ("realiza")
    // Cada encargo tiene UN cliente -> referencia + id
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Cliente Cliente { get; set; } = null!;

    // Relacion EncargoImpresion 1 <>--- 1..* lineaEncargo (contiene)
    public IList<LineaEncargo> LineasEncargo { get; set; }
}