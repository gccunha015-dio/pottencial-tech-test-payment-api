namespace PaymentAPI.Models;

public class ItensDaVenda
{
  public uint Id { get; set; }
  public uint Quantidade { get; set; }
  public Item Item { get; set; }
}