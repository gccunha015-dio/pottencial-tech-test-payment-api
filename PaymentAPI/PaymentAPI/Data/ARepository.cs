namespace PaymentAPI.Data;

public abstract class ARepository
{
  protected readonly ApiContext _context;
  public ARepository(ApiContext context)
  {
    _context = context;
  }

  public async Task Salvar()
  {
    await _context.SaveChangesAsync();
  }
}