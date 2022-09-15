namespace PaymentAPI.Models;

public abstract class AItem
{
  [Required]
  public string Nome { get; set; }
  [Required]
  public decimal PrecoUnitario { get; set; }
  [Required]
  public uint Quantidade { get; set; }
}