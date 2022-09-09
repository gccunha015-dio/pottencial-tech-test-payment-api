using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Context;
public class ApiContext : DbContext
{
  public DbSet<Item> Itens { get; set; }
  public DbSet<ItensDaVenda> ItensDasVendas { get; set; }
  public DbSet<Vendedor> Vendedores { get; set; }
  public DbSet<Venda> Vendas { get; set; }
  public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
}
