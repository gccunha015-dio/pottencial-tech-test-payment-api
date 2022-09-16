namespace PaymentAPI.Services;

public class VendaService
{
  private readonly VendaRepository _repository;
  private readonly Dictionary<EStatus, List<EStatus>> _atualizacoesDeStatusPermitidas = new Dictionary<EStatus, List<EStatus>>
  {
    { EStatus.AGUARDANDO_PAGAMENTO,
      new List<EStatus> { EStatus.PAGAMENTO_APROVADO, EStatus.CANCELADA }},
    { EStatus.PAGAMENTO_APROVADO,
      new List<EStatus> { EStatus.ENVIADO_PARA_TRANSPORTADORA, EStatus.CANCELADA }},
    { EStatus.ENVIADO_PARA_TRANSPORTADORA,
      new List<EStatus> { EStatus.ENTREGUE }}
  };

  public VendaService(VendaRepository repository)
  {
    _repository = repository;
  }

  public async Task<VendaResponse> Criar(VendaRequest request)
  {
    if (request.Itens.Count() < 1
      || request.Itens.Any((item) => item.Quantidade < 1))
      throw new QuantidadeDeItensException();
    var venda = request.ToRecord();
    await _repository.Inserir(venda);
    return venda.ToResponse();
  }

  public async Task<VendaResponse> LerPorId(uint id)
  {
    var venda = await _getRecordById(id);
    return venda.ToResponse();
  }

  public async Task<VendaResponse> AtualizarStatus(uint id, [FromBody] StatusRequest request)
  {
    var venda = await _getRecordById(id);
    EStatus novoStatus = request.Status;
    if (!_podeAtualizarStatus(venda.Status, novoStatus))
      throw new OperacaoInvalidaException();
    venda.Status = novoStatus;
    await _repository.Atualizar(venda);
    return venda.ToResponse();
  }

  private async Task<VendaRecord> _getRecordById(uint id)
  {
    var venda = await _repository.LerPorId(id);
    if (venda == null) throw new IdInvalidoException();
    return venda;
  }

  private bool _podeAtualizarStatus(EStatus anterior, EStatus novo)
  {
    return _atualizacoesDeStatusPermitidas.ContainsKey(anterior)
      && _atualizacoesDeStatusPermitidas[anterior].Contains(novo);
  }
}