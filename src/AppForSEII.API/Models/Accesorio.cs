namespace AppForSEII.API.Models;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;


public class Accesorio
{
    public Accesorio()
    {
        Nombre = string.Empty;
        Compatibilidad = string.Empty;
        LineasCompraAccesorio = new List<LineaCompraAccesorio>();
    }
    public Accesorio(string nombre, CategoriaAccesorio categoria, string compatibilidad, int cantidadDisponible, decimal precio): this()
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
    [Range(0, int.MaxValue, ErrorMessage = "La cantidad disponible debe ser mayor o igual a 0.")]
    public int CantidadDisponible {get;set;}

    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
    [Display(Name = "Precio")]
    [Range(0, float.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0")]
    [Precision(10, 2)]
    public decimal Precio {get;set;}

    public IList<LineaCompraAccesorio> LineasCompraAccesorio {get;set;}




    
}
