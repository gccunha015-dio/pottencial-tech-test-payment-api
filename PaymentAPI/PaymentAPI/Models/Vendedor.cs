namespace PaymentAPI.Models;

public class Vendedor
{
  private uint _id;
  private string _cpf;
  private string _nome;
  public uint Id { get => _id; }
  public string Cpf { get => _cpf; }
  public string Nome { get => _nome; }
  public string Email { get; set; }
  public string Telefone { get; set; }

  public Vendedor(uint id, string cpf, string nome, string email, string telefone)
  {
    _id = id;
    _cpf = cpf;
    _nome = nome;
    Email = email;
    Telefone = telefone;
  }
}