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
  public IActionResult Registrar(Venda venda)
  {
    _context.Vendas.Add(venda);
    _context.SaveChanges();

    return CreatedAtAction(actionName: nameof(BuscarPorId),
                            routeValues: new { id = venda.Id },
                            value: venda);
  }

  [HttpGet("{id}")]
  public IActionResult BuscarPorId(int id)
  {
    Venda venda = _context.Vendas.Find(id);
    if (venda == null) return NotFound();
    return Ok(value: venda);
  }

  [HttpGet]
  public IActionResult Buscar()
  {
    List<Venda> vendas = _context.Vendas.ToList();
    return Ok(value: vendas);
  }
}