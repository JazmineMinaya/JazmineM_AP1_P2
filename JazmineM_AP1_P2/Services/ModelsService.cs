using JazmineM_AP1_P2.Context;
using JazmineM_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Aplicada1.Core;

namespace JazmineM_AP1_P2.Services;

public class ModelsService(
    IDbContextFactory<Contexto> contextFactory
) : IServiceResult<Model, int>
{
    public async Task<Result> Guardar(Model model)
    {
        throw new NotImplementedException();
    }

    private async Task<bool> Existe(int modelId)
    {
        throw new NotImplementedException();
    }

    private async Task<bool> Insertar(Model model)
    {
        throw new NotImplementedException();
    }

    private async Task<bool> Modificar(Model model)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Model?>> Buscar(int modelId)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> Eliminar(int modelId)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<Model>>> GetList(Expression<Func<Model, bool>> criterio)
    {
        throw new NotImplementedException();
    }
}
