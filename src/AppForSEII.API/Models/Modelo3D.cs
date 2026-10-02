namespace AppForSEII.API.Models;

[Index(nameof(Nombre), IsUnique = true)]
public class Modelo3D
{
    public Modelo3D(){}

    public Modelo3D(string nombre, string categoria, FormatoModelo3D formato, decimal precio)
    {
        Nombre = nombre;
        Categoria = categoria;
        Formato = formato;
        Precio = precio;
    }

    public int Id { get; set; }

    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    [Display(Name = "Nombre del Modelo")]
    public string Nombre { get; set; }
    
    [StringLength(50, ErrorMessage = "La categoría no puede tener más de 50 caracteres.")]
    [Display(Name = "Categoría")]
    public string Categoria { get; set; }
    
    [Display(Name = "Formato del Archivo")]
    public FormatoModelo3D Formato { get; set; }
    
    [DataType(System.ComponentModel.DataAnnotations.DataType.Currency)]
    [Range(0.5, double.MaxValue, ErrorMessage = "El precio mínimo es 0.5")]
    [Display(Name = "Precio de Compra")]
    [Precision(10,2)]
    public decimal Precio {get; set; }

    
    public LicenciaModelo3D Licencia { get; set; }

    //Un modelo3D puede aparecer en muchas lineas de compra de distintas
    public IList<LineaCompraModelo> LineasCompra { get; set; }
}