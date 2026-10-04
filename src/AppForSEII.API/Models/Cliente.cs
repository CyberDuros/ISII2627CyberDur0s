namespace AppForSEII.API.Models;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;

public class Cliente : ApplicationUser
{
    public Cliente()
    {
        
    }
    public Cliente(string direccionFacturacion)
    {
        DireccionFacturacion = direccionFacturacion;
    }

    [StringLength(100, ErrorMessage = "La dirección de facturación no puede superar los 100 caracteres.")]
    public string DireccionFacturacion { get; set; }

    public IList<CompraAccesorios> ComprasAccesorios { get; set; }

    public IList<CompraModelo3D> ComprasModelo3D { get; set; }

    public IList<ReservaImpresora> ReservaImpresoras { get; set; }

    public IList<EncargoImpresion> EncargoImpresiones { get; set; }

}
