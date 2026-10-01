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
    public string Nombre {get;set;}
    public CategoriaAccesorio Categoria {get;set;}
    public string Compatibilidad {get;set;}
    public int CantidadDisponible {get;set;}
    public decimal Precio {get;set;}


    
}