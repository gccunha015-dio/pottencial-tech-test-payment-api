using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Context;
using PaymentAPI.Models;

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
    try
    {
      Venda venda = new Venda(vendaDTO);
      await _context.Vendas.AddAsync(venda);
      await _context.SaveChangesAsync();
      return Created("v1", venda);
    }
    catch (Exception e)
    {
      throw e;
    }
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
