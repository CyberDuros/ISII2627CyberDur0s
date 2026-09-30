namespace AppForMovies.API.Models
{
    public class ReservaImpresora
    {
        public ReservaImpresora() {}

        public ReservaImpresora(string nombreCliente,DateTime fechaReserva, string apellidosCliente,string direccionFacturacion, decimal precioTotal,MetodoPago metodoPago)
        {
            NombreCliente = nombreCliente;
             FechaReserva = fechaReserva;
             ApellidosCliente = apellidosCliente;
            DireccionFacturacion = direccionFacturacion;
            PrecioTotal = precioTotal;
             MetodoPago = metodoPago;
        }

        public int Id {get; set;}
        public DateTime FechaReserva {get; set;}
        public string NombreCliente {get; set;}
        public string ApellidosCliente {get; set;}
        public string DireccionFacturacion { get; set; }
        public decimal PrecioTotal { get; set; }
        public MetodoPago MetodoPago { get; set; }
    }
}
