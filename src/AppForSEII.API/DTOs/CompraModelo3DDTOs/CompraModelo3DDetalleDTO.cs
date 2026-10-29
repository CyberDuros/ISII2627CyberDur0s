namespace AppForSEII.API.DTOs.CompraModelo3DDTOs;
using DisplayAttribute = System.ComponentModel.DataAnnotations.DisplayAttribute;
using DataType = System.ComponentModel.DataAnnotations.DataType;

//Heredamos del DTO de CompraModelo3DParaCrearDTO
public class CompraModelo3DDetalleDTO : CompraModelo3DParaCrearDTO
{
    public CompraModelo3DDetalleDTO(int id, DateTime fechaCompra, string nombreCliente, string apellidosCliente,
                                    string correoElectronicoCliente, string direccionFacturacion, MetodoPago metodoPago, 
                                    string? descripcion, IList<LineaCompraModeloDTO> lineasCompra): base(nombreCliente,
                                    apellidosCliente, correoElectronicoCliente, direccionFacturacion, metodoPago,
                                    descripcion, lineasCompra)
    {
        Id = id;
        FechaCompra = fechaCompra;
    }

    public int Id {get; set;}

    [DataType(DataType.DateTime), Display(Name = "Fecha de compra")]
    public DateTime FechaCompra  {get; set;}

    //Metodo para comparar las fechas de compra, en el Equals del DTO de detalle de compra
    private bool CompararFechas(DateTime fecha1, DateTime fecha2)
    {
        return Math.Abs((fecha1 - fecha2).TotalMinutes) < 1;
    }

    //Metodo Equals y GetHashCode
    public override bool Equals(object? obj)
    {
        return obj is CompraModelo3DDetalleDTO dTO &&
            base.Equals(obj) &&
            Id == dTO.Id &&
            CompararFechas(FechaCompra, dTO.FechaCompra);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Id, FechaCompra);
    }
}