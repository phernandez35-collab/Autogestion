using AutoGestion.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoGestion.Data;

public class AutoGestionContext : DbContext
{
    public AutoGestionContext(DbContextOptions<AutoGestionContext> options) : base(options) { }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();
    public DbSet<OrdenReparacion> OrdenesReparacion => Set<OrdenReparacion>();
    public DbSet<Seguimiento> Seguimientos => Set<Seguimiento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehiculo>()
            .HasIndex(v => v.Placas).IsUnique();

        // Un cliente con vehículos no se puede borrar
        modelBuilder.Entity<Vehiculo>()
            .HasOne(v => v.Cliente).WithMany(c => c.Vehiculos)
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        // Un vehículo con órdenes no se puede borrar
        modelBuilder.Entity<OrdenReparacion>()
            .HasOne(o => o.Vehiculo).WithMany(v => v.Ordenes)
            .HasForeignKey(o => o.VehiculoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrdenReparacion>()
            .Property(o => o.Costo).HasPrecision(10, 2);

        // Si se borra una orden, se borra su historial de seguimiento
        modelBuilder.Entity<Seguimiento>()
            .HasOne(s => s.OrdenReparacion).WithMany(o => o.Seguimientos)
            .HasForeignKey(s => s.OrdenReparacionId)
            .OnDelete(DeleteBehavior.Cascade);

        // El estado se guarda como texto legible en la BD
        modelBuilder.Entity<Seguimiento>()
            .Property(s => s.Estado).HasConversion<string>().HasMaxLength(30);
    }
}
