namespace PaymentAPI.Models;

public class Venda
{
  public uint Id { get; set; }
  public decimal Valor { get; set; }
  public DateTime Data { get; set; }
  public Vendedor? Vendedor { get; set; }
  public List<ItensDaVenda>? Itens { get; set; }
}