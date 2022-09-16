namespace PaymentAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class VendaController : ControllerBase
{
  private readonly VendaService _service;
  public VendaController(VendaService service)
  {
    _service = service;
  }

  [HttpPost]
  public async Task<IActionResult> Criar(VendaRequest request)
  {
    var venda = await _service.Criar(request);
    return CreatedAtAction(
      actionName: nameof(LerPorId),
      routeValues: new { id = venda.Id },
      value: venda
    );
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> LerPorId(uint id)
  {
    return Ok(value: await _service.LerPorId(id));
  }

  [HttpPatch("{id}")]
  public async Task<IActionResult> AtualizarStatus(uint id, [FromBody] StatusRequest request)
  {
    return Ok(value: await _service.AtualizarStatus(id, request));
  }
}
