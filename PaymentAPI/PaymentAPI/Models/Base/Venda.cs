namespace PaymentAPI.Models.Base;

public abstract class Venda
{
  public decimal Valor { get; set; }
  public DateTime Data { get; set; }
  public EStatus Status { get; set; }
}