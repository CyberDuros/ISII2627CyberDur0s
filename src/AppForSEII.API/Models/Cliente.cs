namespace AppForSEII.API.Models;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;

public class Cliente : ApplicationUser
{
    public Cliente()
    {
        DireccionFacturacion = string.Empty;
        ComprasAccesorios = new List<CompraAccesorios>();
        ComprasModelo3D = new List<CompraModelo3D>();
        ReservaImpresoras = new List<ReservaImpresora>();
        EncargoImpresiones = new List<EncargoImpresion>();
    }
    public Cliente(string id, string name, string surname, string userName, string direccionFacturacion):base(id, name, surname, userName)
    {
        DireccionFacturacion = direccionFacturacion;
        ComprasAccesorios = new List<CompraAccesorios>();
        ComprasModelo3D = new List<CompraModelo3D>();
        ReservaImpresoras = new List<ReservaImpresora>();
        EncargoImpresiones = new List<EncargoImpresion>();
    }

    [StringLength(100, ErrorMessage = "La dirección de facturación no puede superar los 100 caracteres.")]
    public string DireccionFacturacion { get; set; }

    public IList<CompraAccesorios> ComprasAccesorios { get; set; }

    public IList<CompraModelo3D> ComprasModelo3D { get; set; }

    public IList<ReservaImpresora> ReservaImpresoras { get; set; }

    public IList<EncargoImpresion> EncargoImpresiones { get; set; }

}
