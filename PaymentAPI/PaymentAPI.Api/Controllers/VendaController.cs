using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Api.Data;
using PaymentAPI.Api.Models;

namespace PaymentAPI.Api.Controllers;

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
  public IActionResult Registrar(VendaDTO vendaDTO)
  {
    if (vendaDTO.Vendedor.Cpf.Length != 11) return UnprocessableEntity(new { erro = "CPFs devem ter 11 digitos." });
    if (vendaDTO.Itens.Count < 1
      || vendaDTO.Itens.Any(i => i.Quantidade < 1)) return UnprocessableEntity(new { erro = "Pelo menos 1 item deve estar presente." });
    Venda venda = new Venda(vendaDTO);
    _context.Vendas.Add(venda);
    _context.SaveChanges();

    return CreatedAtAction(actionName: nameof(BuscarPorId),
                            routeValues: new { id = venda.Id },
                            value: venda);
  }

  [HttpGet("{id}")]
  public IActionResult BuscarPorId(uint id)
  {
    Venda venda = _context.Vendas.Find(id);
    if (venda == null) return NotFound();
    _context.Entry(venda).Reference(v => v.Vendedor).Load();
    _context.Entry(venda).Collection(v => v.Itens).Load();
    return Ok(value: venda);
  }
}