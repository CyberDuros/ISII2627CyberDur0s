namespace AppForSEII.API.Models;

using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;
using DataType = System.ComponentModel.DataAnnotations.DataType;

public class Impresora3D
{
    public Impresora3D() { }

    public Impresora3D(string nombre, string modelo, TipoImpresora tipo, string descripcion, decimal preciokilovatiohora, decimal precioreserva)
    {
        Nombre = nombre;
        Modelo = modelo;
        Tipo = tipo;
        Descripcion = descripcion;
        PrecioKilovatioHora = preciokilovatiohora;
        PrecioReserva = precioreserva;
    }

    public int Id { get; set; }

    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    public string Nombre { get; set; }

    [StringLength(50, ErrorMessage = "El modelo no puede tener más de 50 caracteres.")]
    public string Modelo { get; set; }

    [StringLength(50, ErrorMessage = "La descripción no puede tener más de 50 caracteres.")]
    public string Descripcion { get; set; }


    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
    [Range(0.0001, float.MaxValue, ErrorMessage = "El valor minimo permitido es 0.5")]
    [Display(Name = "Precio por kilovatio hora")]
    [Precision(10, 4)]
    public decimal PrecioKilovatioHora { get; set; }

    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
    [Range(0.5, float.MaxValue, ErrorMessage = "El valor minimo permitido es 0.5")]
    [Display(Name = "Precio de reserva")]
    [Precision(10, 2)]
    public decimal PrecioReserva { get; set; }


    public TipoImpresora Tipo { get; set; }

    public IList<LineaReserva> LineasReserva { get; set; }





}

