namespace AppForSEII.API.DTOs.CompraModelo3DDTOs;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;
using DataType = System.ComponentModel.DataAnnotations.DataType;

public class LineaCompraModeloDTO
{
    public LineaCompraModeloDTO()
    {
        Nombre = string.Empty;
        Categoria = string.Empty;
    }

    public LineaCompraModeloDTO(int modelo3DId, string nombre, string categoria, FormatoModelo3D formato, decimal precioUnidad, int cantidadLicencias, DateTime fechaExpiracionLicencia)
    {
        Modelo3DId = modelo3DId;
        Nombre = nombre;
        Categoria = categoria;
        Formato = formato;
        PrecioUnidad = precioUnidad;
        CantidadLicencias = cantidadLicencias;
        FechaExpiracionLicencia = fechaExpiracionLicencia;
    }

    public int Modelo3DId { get; set; }

    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; }

    [StringLength(50, ErrorMessage = "La categoría no puede tener más de 50 caracteres.")]
    [Display(Name = "Categoría")]
    public string Categoria { get; set; }

    [Display(Name = "Formato del Archivo")]
    public FormatoModelo3D Formato { get; set; }

    [DataType(DataType.Currency)]
    [Display(Name = "Precio por unidad")]
    public decimal PrecioUnidad { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad mínima de licencias es 1")]
    [Display(Name = "Cantidad de licencias")]
    public int CantidadLicencias { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Fecha de expiración de la licencia")]
    public DateTime FechaExpiracionLicencia { get; set; }

    [DataType(DataType.Currency)]
    public decimal Subtotal => PrecioUnidad * CantidadLicencias;

    //Metodo Equals y GetHashCode
    public override bool Equals(object? obj)
    {
        return obj is LineaCompraModeloDTO dTO &&
            Modelo3DId == dTO.Modelo3DId &&
            Nombre == dTO.Nombre &&
            Categoria == dTO.Categoria &&
            Formato == dTO.Formato &&
            PrecioUnidad == dTO.PrecioUnidad &&
            CantidadLicencias == dTO.CantidadLicencias &&
            FechaExpiracionLicencia == dTO.FechaExpiracionLicencia;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Modelo3DId, Nombre, Categoria, Formato, PrecioUnidad, CantidadLicencias, FechaExpiracionLicencia);
    }
}