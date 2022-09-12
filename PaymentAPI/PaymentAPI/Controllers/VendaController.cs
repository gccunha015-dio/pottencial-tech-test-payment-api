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
    Venda venda = await _context.Vendas.FindAsync(id);
    if (venda == null) throw new ApiException(
      message: "Id invalido.",
      statusCode: StatusCodes.Status404NotFound);
    _context.Entry(venda).Reference(v => v.Vendedor).Load();
    _context.Entry(venda).Collection(v => v.Itens).Load();
    return Ok(value: venda);
  }

  [HttpPatch("{id}")]
  public async Task<IActionResult> AtualizarStatus(uint id, [FromBody] EStatusDTO novoStatus)
  {
    Venda venda = await _context.Vendas.FindAsync(id);
    if (venda == null) throw new ApiException(
      message: "Id invalido.",
      statusCode: StatusCodes.Status404NotFound);
    venda.Status = novoStatus.Status;
    await _context.SaveChangesAsync();
    return Ok(value: venda);
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
}
