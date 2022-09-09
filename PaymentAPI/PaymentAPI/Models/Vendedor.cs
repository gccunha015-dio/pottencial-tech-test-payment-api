using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models;

public class Vendedor : VendedorDTO
{
  public Vendedor() { }
  public Vendedor(VendedorDTO vendedorDTO)
  {
    Id = vendedorDTO.Id;
    Cpf = vendedorDTO.Cpf;
    Nome = vendedorDTO.Nome;
    Email = vendedorDTO.Email;
    Telefone = vendedorDTO.Telefone;
  }
}

public class VendedorDTO
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