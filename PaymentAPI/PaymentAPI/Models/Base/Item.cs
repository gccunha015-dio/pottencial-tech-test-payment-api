namespace PaymentAPI.Models.Base;

public abstract class Item
{
  [Required]
  public string Nome { get; set; }
  [Required]
  public decimal PrecoUnitario { get; set; }
  [Required]
  public uint Quantidade { get; set; }
}