namespace PaymentAPI.Models;

public class Vendedor
{
  public uint Id { get; set; }
  public string? Cpf { get; set; }
  public string? Nome { get; set; }
  public string? Email { get; set; }
  public string? Telefone { get; set; }
}