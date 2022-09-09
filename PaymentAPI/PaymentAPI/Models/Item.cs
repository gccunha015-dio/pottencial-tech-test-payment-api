namespace PaymentAPI.Models;

public class Item
{
  private uint _id;
  private string _nome;
  public uint Id { get => _id; }
  public string Nome { get => _nome; }
  public decimal PrecoUnitario { get; set; }
  public Item(uint id, string nome, decimal precoUnitario)
  {
    _id = id;
    _nome = nome;
    PrecoUnitario = precoUnitario;
  }
}