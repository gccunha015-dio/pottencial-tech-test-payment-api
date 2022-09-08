using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Api.Models;

public class Item
{
  [Key, Required]
  public uint Id { get; set; }
  [Required]
  public string Nome { get; set; }
  [Required]
  public decimal PrecoUnitario { get; set; }
  [Required]
  public uint Quantidade { get; set; }
}