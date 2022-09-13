using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Context;
using PaymentAPI.Models;
using PaymentAPI.Helpers;

namespace PaymentAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class VendaController : ControllerBase
{
  private readonly ApiContext _context;
  private Dictionary<EStatus, List<EStatus>> _atualizacoesDeStatusPermitidas = new Dictionary<EStatus, List<EStatus>>
  {
    { EStatus.AGUARDANDO_PAGAMENTO,
      new List<EStatus> { EStatus.PAGAMENTO_APROVADO, EStatus.CANCELADA }},
    { EStatus.PAGAMENTO_APROVADO,
      new List<EStatus> { EStatus.ENVIADO_PARA_TRANSPORTADORA, EStatus.CANCELADA }},
    { EStatus.ENVIADO_PARA_TRANSPORTADORA,
      new List<EStatus> { EStatus.ENTREGUE }}
  };
  public VendaController(ApiContext context)
  {
    _context = context;
  }

  [HttpPost]
  public async Task<IActionResult> Criar(VendaDTO vendaDTO)
  {
    if (vendaDTO.Itens.Count() < 1
      || vendaDTO.Itens.Any((itemDTO) => itemDTO.Quantidade < 1))
      throw new ApiException(
        message: "A inclusão de uma venda deve possuir pelo menos 1 item.",
        statusCode: StatusCodes.Status422UnprocessableEntity);
    Venda venda = new Venda(vendaDTO);
    await _context.Vendas.AddAsync(venda);
    await _context.SaveChangesAsync();
    return Created("v1", venda);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> LerPorId(uint id)
  {
    return Ok(value: await _lerDoBancoDeDados(id));
  }

  [HttpPatch("{id}")]
  public async Task<IActionResult> AtualizarStatus(uint id, [FromBody] EStatusDTO novoStatusDTO)
  {
    Venda venda = await _lerDoBancoDeDados(id);
    EStatus novoStatus = novoStatusDTO.Status;
    if (!_podeAtualizarStatus(venda.Status, novoStatus)) throw new ApiException(
      message: "Operacao invalida.",
      statusCode: StatusCodes.Status400BadRequest);
    venda.Status = novoStatus;
    await _context.SaveChangesAsync();
    return Ok(value: venda);
  }

  private async Task<Venda> _lerDoBancoDeDados(uint id)
  {
    Venda venda = await _context.Vendas.FindAsync(id);
    if (venda == null) throw new ApiException(
      message: "Id invalido.",
      statusCode: StatusCodes.Status404NotFound);
    _context.Entry(venda).Reference(v => v.Vendedor).Load();
    _context.Entry(venda).Collection(v => v.Itens).Load();
    return venda;
  }

  [HttpGet]
  public IActionResult Ler()
  {
    return Ok(new
    {
      vendas = _context.Vendas.ToArray(),
      vendedores = _context.Vendedores.ToArray(),
      itens = _context.Itens.ToArray()
    });
  }

  private bool _podeAtualizarStatus(EStatus anterior, EStatus novo)
  {
    return _atualizacoesDeStatusPermitidas.ContainsKey(anterior)
      && _atualizacoesDeStatusPermitidas[anterior].Contains(novo);
  }
}
