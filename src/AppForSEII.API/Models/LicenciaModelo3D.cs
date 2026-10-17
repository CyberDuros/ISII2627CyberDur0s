namespace AppForSEII.API.Models;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;
using DataType = System.ComponentModel.DataAnnotations.DataType;

public class LicenciaModelo3D
{
    public LicenciaModelo3D()
    {
        Nombre = string.Empty;
        Modelos3D = new List<Modelo3D>();
    }

    public LicenciaModelo3D(string nombre, DateTime fechaExpiracion) : this()
    {
        Nombre = nombre;
        FechaExpiracion = fechaExpiracion;
    }

    public int Id { get; set; }

    [StringLength(50, ErrorMessage = "El nombre de la licencia no puede tener mas de 50 caracteres")]
    [Display(Name = "Licencia")]
    public string Nombre { get; set; }

    [DataType(DataType.DateTime), Display(Name = "Fecha de expiracion")]
    public DateTime FechaExpiracion { get; set; }
    //Una licencia puede estar asignada a 0..* modelos 3D
    public IList<Modelo3D> Modelos3D { get; set; }
}