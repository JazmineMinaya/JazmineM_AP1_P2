using Microsoft.EntityFrameworkCore;
using JazmineM_AP1_P2.Models;

namespace JazmineM_AP1_P2.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Model> Models { get; set; }
}
