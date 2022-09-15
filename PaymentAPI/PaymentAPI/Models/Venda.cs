namespace PaymentAPI.Models;

public class Venda
{
  public uint Id { get; set; }
  public decimal Valor { get; private set; }
  public DateTime Data { get; set; } = DateTime.Now;
  public EStatus Status { get; set; } = EStatus.AGUARDANDO_PAGAMENTO;
  public Vendedor Vendedor { get; set; }
  public IEnumerable<Item> Itens { get; set; }
  // private IEnumerable<Item> _gerarItens(IEnumerable<AItem> itens)
  // {
  //   return itens.Select((item) => new Item(item))
  //     .ToList<Item>();
  // }
  private decimal _calcularValor()
  {
    return Itens.Aggregate(seed: 0.0M,
    (soma, item) => soma + item.PrecoUnitario * item.Quantidade);
  }
}