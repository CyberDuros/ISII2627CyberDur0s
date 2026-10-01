namespace AppFORSEII.API.Models;

public class LicenciaModelo3D
{
    public LicenciaModelo3D(){}

    public LicenciaModelo3D(string nombre, DateTime fechaExpiracion)
    {
        Nombre = nombre;
        FechaExpiracion = fechaExpiracion;
    }

    public int Id { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaExpiracion { get; set; }
}