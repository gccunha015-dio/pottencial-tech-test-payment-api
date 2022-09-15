namespace PaymentAPI.Data;

public class VendaRepository : ARepository, IRepository<Venda>
{
  public VendaRepository(ApiContext context) : base(context) { }

  public async Task<Venda> GetById(uint id)
  {
    return await _context.Vendas.FindAsync(id);
  }

  public async Task Insert(Venda venda)
  {
    await _context.Vendas.AddAsync(venda);
    await Save();
  }

  public async Task Update(Venda venda)
  {
    _context.Vendas.Update(venda);
    await Save();
  }

  public async Task Save()
  {
    await _context.SaveChangesAsync();
  }
}