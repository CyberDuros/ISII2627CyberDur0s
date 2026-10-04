namespace AppForSEII.API.Models;

// Add profile data for application users by adding properties to the ApplicationUser class
public class Accesorio
{
    public Accesorio()
    {
    }
    public Accesorio(string nombre, CategoriaAccesorio categoria, string compatibilidad, int cantidadDisponible, decimal precio)
    {
        Nombre = nombre;
        Categoria = categoria;
        Compatibilidad = compatibilidad;
        CantidadDisponible = cantidadDisponible;
        Precio = precio;
    }
    public int Id {get;set;}

    [StringLength(100, ErrorMessage = "El nombre no puede tener mas de 100 caracteres.")]
    public string Nombre {get;set;}
    public CategoriaAccesorio Categoria {get;set;}

    [StringLength(200, ErrorMessage = "La compatibilidad no puede tener mas de 200 caracteres.")]
    public string Compatibilidad {get;set;}
    
    [Display(Name = "Cantidad Disponible")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad disponible debe ser mayor a 0.")]
    public int CantidadDisponible {get;set;}

    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
    [Display(Name = "Precio")]
    [Precision(10, 2)]
    public decimal Precio {get;set;}

    public IList<LineaCompraAccesorio> LineasCompraAccesorio {get;set;}




    
}