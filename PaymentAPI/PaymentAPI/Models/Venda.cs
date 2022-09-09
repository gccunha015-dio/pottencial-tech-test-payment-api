namespace PaymentAPI.Models;

public class Venda
{
  private uint _id;
  private uint _vendedorId;
  private decimal _valor = 0;
  private DateTime _data = DateTime.Now;
  public uint Id { get => _id; }
  public uint VendedorId { get => _vendedorId; }
  public decimal Valor { get => _valor; }
  public DateTime Data { get => _data; }
  public Venda(uint id, uint vendedorId)
  {
    _id = id;
    _vendedorId = vendedorId;
  }
}