using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Api.Models;

public class Venda
{
  public uint Id { get; set; }
  public DateTime Data { get; set; }
  public EStatus Status { get; set; }
  public Vendedor Vendedor { get; set; }
  public List<Item> Itens { get; set; }
  public Venda() { }
  public Venda(VendaDTO vendaDTO)
  {
    Vendedor = vendaDTO.Vendedor;
    Itens = vendaDTO.Itens;
    Data = DateTime.Now;
  }
}

public class VendaDTO
{
  [Required]
  public Vendedor Vendedor { get; set; }
  [Required]
  public List<Item> Itens { get; set; }
}