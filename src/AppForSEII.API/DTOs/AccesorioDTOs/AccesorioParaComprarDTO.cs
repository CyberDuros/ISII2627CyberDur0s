namespace AppForSEII.API.DTOs.AccesorioDTOs;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;
using DataType = System.ComponentModel.DataAnnotations.DataType;

public class AccesorioParaComprarDTO
{
    public AccesorioParaComprarDTO(int id, string nombre, CategoriaAccesorio categoria, string compatibilidad, int cantidadDisponible, decimal precio)
    {
        Id = id;
        Nombre = nombre;
        Categoria = categoria;
        Compatibilidad = compatibilidad;
        CantidadDisponible = cantidadDisponible;
        Precio = precio;
    }
    public int Id { get; set; }

    [StringLength(100, ErrorMessage = "El nombre no puede tener mas de 100 caracteres.")]
    [Display(Name = "Nombre")]
    public string Nombre {get;set;}

    [Display(Name = "Categoría")]
    public CategoriaAccesorio Categoria {get;set;}

    [StringLength(200, ErrorMessage = "La compatibilidad no puede tener mas de 200 caracteres.")]
    [Display(Name = "Compatibilidad")]
    public string Compatibilidad {get;set;}
    [Display(Name = "Cantidad Disponible")]
    public int CantidadDisponible {get;set;}

    [DataType(DataType.Currency)]
    [Display(Name = "Precio")]
    public decimal Precio {get;set;}
    
    public override bool Equals(object? obj)
    {
        return obj is AccesorioParaComprarDTO dTO &&
               Id == dTO.Id &&
               Nombre == dTO.Nombre &&
               Categoria == dTO.Categoria &&
               Compatibilidad == dTO.Compatibilidad &&
               CantidadDisponible == dTO.CantidadDisponible &&
               Precio == dTO.Precio;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Nombre, Categoria, Compatibilidad, CantidadDisponible, Precio);
    }


}
