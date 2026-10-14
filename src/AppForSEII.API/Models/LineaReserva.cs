namespace AppForSEII.API.Models;

using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;
using DataType = System.ComponentModel.DataAnnotations.DataType;

public class LineaReserva
{
    public LineaReserva()
    {
        Impresora = new Impresora3D();
        ReservaImpresora = new ReservaImpresora();
    }

    public LineaReserva(TiempoReserva tiempoReserva, decimal precioSubtotal, Impresora3D impresora, ReservaImpresora reservaImpresora): this()
    {
        TiempoReserva = tiempoReserva;
        PrecioSubtotal = precioSubtotal;
        Impresora = impresora;
        ReservaImpresora = reservaImpresora;
    }

    public int Id { get; set; }


    public TiempoReserva TiempoReserva { get; set; }

    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
    [Range(0.5, float.MaxValue, ErrorMessage = "El valor minimo permitido es 0.5")]
    [Display(Name = "Precio subtotal")]
    [Precision(10, 2)]
    public decimal PrecioSubtotal { get; set; }



    public Impresora3D Impresora { get; set; }
    public ReservaImpresora ReservaImpresora { get; set; }


}

