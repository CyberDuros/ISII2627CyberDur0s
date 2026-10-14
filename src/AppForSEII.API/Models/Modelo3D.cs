namespace AppForSEII.API.Models;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;
using DataType = System.ComponentModel.DataAnnotations.DataType;

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
    public string Nombre { get; set; }
    
    [StringLength(50, ErrorMessage = "La categoría no puede tener más de 50 caracteres.")]
    public string Categoria { get; set; }
    
    [Display(Name = "Formato del Archivo")]
    public FormatoModelo3D Formato { get; set; }
    
    [DataType(DataType.Currency)]
    [Display(Name = "Precio de Compra")]
    [Precision(10,2)]
    public decimal Precio {get; set; }
    
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public LicenciaModelo3D Licencia { get; set; }

    //Un modelo3D puede aparecer en muchas lineas de compra de distintas
    public IList<LineaCompraModelo> LineasCompraModelo { get; set; }
}