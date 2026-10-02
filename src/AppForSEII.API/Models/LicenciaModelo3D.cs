namespace AppForSEII.API.Models;

public class LicenciaModelo3D
{
    public LicenciaModelo3D() {}

    public int Id { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaExpiracion { get; set; }
    //Una licencia puede estar asignada a 0..* modelos 3D
    public IList<Modelo3D> Modelos3D { get; set; }
}