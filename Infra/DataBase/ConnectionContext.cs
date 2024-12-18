using Microsoft.EntityFrameworkCore;
using colaboradorApi.Models;

namespace colaboradorApi.Infra.DataBase;

public class ConnectionContext : DbContext
{
    public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options){}
    
    public DbSet<Colaborador> Colaboradores { get; set; }
}