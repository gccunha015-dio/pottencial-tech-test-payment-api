namespace PaymentAPI.Api.Models;

public class Venda
{
  public int Id { get; set; }
  public Vendedor Vendedor { get; set; }
  public DateTime Data { get; set; }
  public List<Item> Itens { get; set; }
  public EStatus Status { get; set; }
}