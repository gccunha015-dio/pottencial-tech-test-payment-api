namespace PaymentAPI.Api.Models;

public class Venda
{
  public int Id { get; set; }
  public int Vendedor { get; set; }
  public DateTime Data { get; set; }
  public List<int> Itens { get; set; }
}