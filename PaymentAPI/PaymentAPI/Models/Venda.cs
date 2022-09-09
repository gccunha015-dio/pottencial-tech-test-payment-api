using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models;

public class Venda : VendaDTO
{
  public uint Id { get; set; }
  public decimal Valor { get; set; }
  public DateTime Data { get; set; }
  public EStatus Status { get; set; }
  public Venda() { }
  public Venda(VendaDTO vendaDTO)
  {
    Vendedor = vendaDTO.Vendedor;
    Itens = vendaDTO.Itens;
  }
}

public class VendaDTO
{
  [Required]
  public Vendedor Vendedor { get; set; }
  [Required]
  public IEnumerable<Item> Itens { get; set; }
  public VendaDTO() { }
}