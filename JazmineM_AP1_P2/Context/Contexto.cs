using Microsoft.EntityFrameworkCore;
using JazmineM_AP1_P2.Models;

namespace JazmineM_AP1_P2.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Ventas> Ventas { get; set; }
    public DbSet<DetalleVentas> DetalleVentas { get; set; }
    public DbSet<Productos> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Productos>().HasData(

            new Productos
            {
                ProductoId = 1,
                Nombre = "Mocha",
                Precio = 175.00,
                Stock = 10
            },

            new Productos
            {
                ProductoId = 2,
                Nombre = "Vanilla",
                Precio = 170.00,
                Stock = 17
            },

            new Productos
            {
                ProductoId = 3,
                Nombre = "Caramel",
                Precio = 180.00,
                Stock = 10
            },

            new Productos
            {
                ProductoId = 4,
                Nombre = "Coffee",
                Precio = 160.00,
                Stock = 12
            },

            new Productos
            {
                ProductoId = 5,
                Nombre = "White Mocha",
                Precio = 195.00,
                Stock = 10
            }

        );
    }
}
