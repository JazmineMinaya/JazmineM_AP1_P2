using JazmineM_AP1_P2.Context;
using JazmineM_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Aplicada1.Core;

namespace JazmineM_AP1_P2.Services;

public class ProductosService(
    IDbContextFactory<Contexto> contextFactory
) : IServiceResult<Productos, int>
{
    public async Task<Result> Guardar(Productos producto)
    {
        throw new NotImplementedException();
    }

    private async Task<bool> Existe(int productoId)
    {
        throw new NotImplementedException();
    }

    private async Task<bool> Insertar(Productos producto)
    {
        throw new NotImplementedException();
    }

    private async Task<bool> Modificar(Productos producto)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Productos?>> Buscar(int productoId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Productos
            .FirstOrDefaultAsync(e => e.ProductoId == productoId);
    }

    public async Task<Result> Eliminar(int productoId)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<Productos>>> GetList(Expression<Func<Productos, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Productos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
