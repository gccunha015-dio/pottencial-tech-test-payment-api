namespace PaymentAPI.Models;

public class Item : ItemDTO
{
  public uint Id { get; set; }
  public Item() { }
  public Item(ItemDTO itemDTO)
  {
    Nome = itemDTO.Nome;
    PrecoUnitario = itemDTO.PrecoUnitario;
    Quantidade = itemDTO.Quantidade;
  }
}

public class ItemDTO
{
  [Required]
  public string Nome { get; set; }
  [Required]
  public decimal PrecoUnitario { get; set; }
  [Required]
  public uint Quantidade { get; set; }
}