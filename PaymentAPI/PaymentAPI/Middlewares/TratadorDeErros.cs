namespace PaymentAPI.Middlewares;

public class TratadorDeErros
{
  private readonly RequestDelegate _proximaChamada;

  public TratadorDeErros(RequestDelegate proximaChamada)
  {
    _proximaChamada = proximaChamada;
  }
  public async Task InvokeAsync(HttpContext contexto)
  {
    try
    {
      await _proximaChamada(contexto);
    }
    catch (Exception exception)
    {
      await _handleExceptionAsync(contexto, exception);
    }
  }
  private async Task _handleExceptionAsync(HttpContext contexto, Exception excecao)
  {
    var resposta = contexto.Response;
    resposta.ContentType = "application/json";
    switch (excecao)
    {
      case ApiException ex:
        resposta.StatusCode = ex.Status;
        break;
      default:
        resposta.StatusCode = StatusCodes.Status500InternalServerError;
        break;
    }
    var json = JsonSerializer.Serialize(
      new { erro = excecao.Message }
    );
    await resposta.WriteAsync(json);
  }
}
