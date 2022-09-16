namespace PaymentAPI.Models.Request;

public class VendaRequest : IRequest<VendaRecord>
{
  [Required]
  public VendedorRequest Vendedor { get; set; }
  [Required]
  public IEnumerable<ItemRequest> Itens { get; set; }

  public VendaRecord ToRecord()
  {
    return new VendaRecord
    {
      Valor = _calcularValor(),
      Data = DateTime.Now,
      Status = EStatus.AGUARDANDO_PAGAMENTO,
      Vendedor = this.Vendedor.ToRecord(),
      Itens = _transformItensRequestToRecord()
    };
  }

  private List<ItemRecord> _transformItensRequestToRecord()
  {
    return Itens.Select(
      (item) => item.ToRecord()
    ).ToList<ItemRecord>();
  }

  private decimal _calcularValor()
  {
    return Itens.Aggregate(
      seed: 0.0M,
      (soma, item) => soma + item.PrecoUnitario * item.Quantidade
    );
  }
}