namespace AppForSEII.API.Models;

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

    public IList<EncargoImpresion> EncargoImpresiones { get; set; }

}