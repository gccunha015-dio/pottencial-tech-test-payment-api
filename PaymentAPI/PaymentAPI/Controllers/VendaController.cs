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
      _validarEntrada(vendaDTO);
      Venda venda = new Venda(vendaDTO);
      await _context.Vendas.AddAsync(venda);
      await _context.SaveChangesAsync();
      return Created("v1", venda);
    }
    catch (Exception e)
    {
      return UnprocessableEntity(new { erro = e.Message });
    }
  }
  [HttpGet("{id}")]
  public async Task<IActionResult> LerPorId(uint id)
  {
    try
    {
      Venda venda = await _context.Vendas.FindAsync(id);
      if (venda == null) throw new Exception("Id invalido.");
      _context.Entry(venda).Reference(v => v.Vendedor).Load();
      _context.Entry(venda).Collection(v => v.Itens).Load();
      return Ok(value: venda);
    }
    catch (Exception e)
    {
      return NotFound(new { erro = e.Message });
    }
  }
  private void _validarEntrada(VendaDTO vendaDTO)
  {
    if (vendaDTO.Itens.Count() < 1
            || vendaDTO.Itens.Any((itemDTO) => itemDTO.Quantidade < 1))
      throw new Exception("A inclusão de uma venda deve possuir pelo menos 1 item.");
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
