using System.Text.Json;

using PaymentAPI.Helpers;

namespace PaymentAPI.Middlewares;

public class ExceptionHandler
{
  private readonly RequestDelegate _next;

  public ExceptionHandler(RequestDelegate next)
  {
    _next = next;
  }
  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (Exception exception)
    {
      await HandleExceptionAsync(context, exception);
    }
  }
  private async Task HandleExceptionAsync(HttpContext context, Exception exception)
  {
    var response = context.Response;
    response.ContentType = "application/json";

    switch (exception)
    {
      case ApiException ex:
        response.StatusCode = ex.StatusCode;
        break;
      default:
        response.StatusCode = StatusCodes.Status500InternalServerError;
        break;
    }
    var json = JsonSerializer.Serialize(new { erro = exception?.Message });
    await response.WriteAsync(json);
  }
}