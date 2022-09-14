namespace PaymentAPI.Models;

public class Venda
{
  public uint Id { get; set; }
  public decimal Valor { get; set; }
  public DateTime Data { get; set; } = DateTime.Now;
  public EStatus Status { get; set; } = EStatus.AGUARDANDO_PAGAMENTO;
  public Vendedor Vendedor { get; set; }
  public IEnumerable<Item> Itens { get; set; }
  public Venda() { }
  public Venda(VendaDTO vendaDTO)
  {
    Vendedor = new Vendedor(vendaDTO.Vendedor);
    Itens = _gerarItens(vendaDTO.Itens);
    Valor = _calcularValor();
  }
  private IEnumerable<Item> _gerarItens(IEnumerable<ItemDTO> itemDTOs)
  {
    return itemDTOs.Select((itemDTO) => new Item(itemDTO))
      .ToList<Item>();
  }
  private decimal _calcularValor()
  {
    return Itens.Aggregate(seed: 0.0M,
    (soma, item) => soma + item.PrecoUnitario * item.Quantidade);
  }
}

public class VendaDTO
{
  [Required]
  public VendedorDTO Vendedor { get; set; }
  [Required]
  public IEnumerable<ItemDTO> Itens { get; set; }
}