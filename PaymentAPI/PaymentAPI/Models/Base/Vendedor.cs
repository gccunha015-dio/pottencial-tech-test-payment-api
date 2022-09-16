namespace PaymentAPI.Models.Base;

public abstract class Vendedor
{
  [Required]
  public uint Id { get; set; }
  [Required]
  public string Cpf { get; set; }
  [Required]
  public string Nome { get; set; }
  [Required]
  public string Email { get; set; }
  [Required]
  public string Telefone { get; set; }
}