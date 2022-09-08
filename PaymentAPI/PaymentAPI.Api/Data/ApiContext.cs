using Microsoft.EntityFrameworkCore;
using PaymentAPI.Api.Models;

namespace PaymentAPI.Api.Data;
public class ApiContext : DbContext
{
  public DbSet<Venda> Vendas { get; set; }
  public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
}
