using JazmineM_AP1_P2.Context;
using JazmineM_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Aplicada1.Core;

namespace JazmineM_AP1_P2.Services;

public class VentasService(
    IDbContextFactory<Contexto> contextFactory
) : IServiceResult<Ventas, int>
{
    public async Task<Result> Guardar(Ventas venta)
    {
        if (!await Existe(venta.VentaId))
        {
            var inserto = await Insertar(venta);
            return Result.Success(inserto);
        }
        else
        {
            var modifico = await Modificar(venta);
            return Result.Success(modifico);
        }
    }

    private async Task<bool> Existe(int ventaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .AnyAsync(e => e.VentaId == ventaId);
    }

    private async Task<bool> Insertar(Ventas venta)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Ventas.Add(venta);

        await AfectarStock(
            venta.DetalleVentas.ToArray(),
            TipoOperacion.Resta,
            contexto);

        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task AfectarStock(
        DetalleVentas[] detalles,
        TipoOperacion tipoOperacion,
        Contexto contexto)
    {
        foreach (var detalle in detalles)
        {
            var producto = await contexto.Productos
                .SingleAsync(e => e.ProductoId == detalle.ProductoId);

            if (tipoOperacion == TipoOperacion.Suma)
                producto.Stock += detalle.Cantidad;
            else
                producto.Stock -= detalle.Cantidad;
        }
    }

    private async Task<bool> Modificar(Ventas venta)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();

        var ventaInicial = await contexto.Ventas
            .Include(a => a.DetalleVentas)
            .FirstOrDefaultAsync(a => a.VentaId == venta.VentaId);

        if (ventaInicial == null)
            return false;

        await AfectarStock(
            ventaInicial.DetalleVentas.ToArray(),
            TipoOperacion.Suma,
            contexto);

        contexto.RemoveRange(ventaInicial.DetalleVentas);

        await AfectarStock(
            venta.DetalleVentas.ToArray(),
            TipoOperacion.Resta,
            contexto);

        ventaInicial.Fecha = venta.Fecha;
        ventaInicial.Observacion = venta.Observacion;
        ventaInicial.Total = venta.Total;
        ventaInicial.DetalleVentas = venta.DetalleVentas
            .Select(d => new DetalleVentas
            {
                VentaId = ventaInicial.VentaId,
                ProductoId = d.ProductoId,
                Cantidad = d.Cantidad,
                Precio = d.Precio
            })
            .ToList();

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Result<Ventas?>> Buscar(int ventaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .Include(a => a.DetalleVentas)
                .ThenInclude(d => d.Producto)
            .FirstOrDefaultAsync(a => a.VentaId == ventaId);
    }

    public async Task<Result> Eliminar(int ventaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();

        var venta = await contexto.Ventas
            .Include(a => a.DetalleVentas)
            .FirstOrDefaultAsync(a => a.VentaId == ventaId);

        if (venta == null)
            return Result.Success(false);

        await AfectarStock(
            venta.DetalleVentas.ToArray(),
            TipoOperacion.Suma,
            contexto);

        contexto.RemoveRange(venta.DetalleVentas);
        contexto.Ventas.Remove(venta);

        var eliminado = await contexto.SaveChangesAsync() > 0;
        return Result.Success(eliminado);
    }

    public async Task<Result<List<Ventas>>> GetList(Expression<Func<Ventas, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .Include(a => a.DetalleVentas)
                .ThenInclude(d => d.Producto)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public enum TipoOperacion
    {
        Suma,
        Resta
    }
}
