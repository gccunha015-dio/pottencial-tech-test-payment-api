namespace PaymentAPI.Models;

public class ItensDaVenda
{
  private uint _vendaId;
  private uint _itemId;
  public uint VendaId { get => _vendaId; }
  public uint ItemId { get => _itemId; }
  public uint Quantidade { get; set; }
  public ItensDaVenda(uint vendaId, uint itemId, uint quantidade)
  {
    _vendaId = vendaId;
    _itemId = itemId;
    Quantidade = quantidade;
  }
}