namespace AppForSEII.API.DTOs.Modelo3DDTOs;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;
using DataType = System.ComponentModel.DataAnnotations.DataType;

public class Modelo3DParaComprarDTO
{
    public Modelo3DParaComprarDTO(int id, string nombre, string categoria, string licencia, FormatoModelo3D formato, decimal precio)
    {
        Id = id;
        Nombre = nombre;
        Categoria = categoria;
        Licencia = licencia;
        Formato = formato;
        Precio = precio;
    }

    public int Id {get; set;}

    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; }

    [StringLength(50, ErrorMessage = "La categoría no puede tener más de 50 caracteres.")]
    [Display(Name = "Categoría")]
    public string Categoria { get; set; }

    // Aplanado: en vez del objeto LicenciaModelo3D, solo su nombre
    [Display(Name = "Licencia")]
    public string Licencia { get; set; }

    [Display(Name = "Formato del Archivo")]
    public FormatoModelo3D Formato { get; set; }

    [DataType(DataType.Currency)]
    [Display(Name = "Precio de Compra")]
    public decimal Precio { get; set; }

    //Metodo Equals y GetHashCode
    public override bool Equals(object? obj)
    {
        return obj is Modelo3DParaComprarDTO dTO &&
               Id == dTO.Id &&
               Nombre == dTO.Nombre &&
               Categoria == dTO.Categoria &&
               Licencia == dTO.Licencia &&
               Formato == dTO.Formato &&
               Precio == dTO.Precio;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Nombre, Categoria, Licencia, Formato, Precio);
    }
}