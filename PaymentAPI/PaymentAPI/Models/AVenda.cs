namespace PaymentAPI.Models;

public abstract class AVenda
{
  [Required]
  public AVendedor Vendedor { get; set; }
  [Required]
  public IEnumerable<AItem> Itens { get; set; }
}