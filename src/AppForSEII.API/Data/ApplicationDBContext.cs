using AppForSEII.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppForSEII.API.DTOs.ApplicationUserDTO;

namespace AppForSEII.API.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);


    }
  
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<ReservaImpresora> ReservaImpresoras { get; set; }
    public DbSet<LineaReserva> LineasReservas { get; set; }
    public DbSet<Impresora3D> Impresoras3D { get; set; }
    public DbSet<CompraModelo3D> ComprasModelos3D { get; set; }
    public DbSet<Modelo3D> Modelos3D { get; set; }
    public DbSet<LineaCompraModelo> LineasCompraModelo { get; set; }
    public DbSet<LicenciaModelo3D> LicenciasModelo3D { get; set; }
    public DbSet<Accesorio> Accesorios { get; set; }
    public DbSet<LineaCompraAccesorio> LineasCompraAccesorios { get; set; }
    public DbSet<CompraAccesorios> ComprasAccesorios { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

}