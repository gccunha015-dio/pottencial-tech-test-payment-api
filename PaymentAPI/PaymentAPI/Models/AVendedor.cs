namespace PaymentAPI.Models;

public abstract class AVendedor
{
  [Required]
  public string Cpf { get; set; }
  [Required]
  public string Nome { get; set; }
  [Required]
  public string Email { get; set; }
  [Required]
  public string Telefone { get; set; }
}