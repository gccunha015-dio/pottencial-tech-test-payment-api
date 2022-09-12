namespace PaymentAPI.Helpers;

public class ApiException : Exception
{
  public int StatusCode { get; set; }
  public ApiException() : base() { }
  public ApiException(string message, int statusCode = 400) : base(message)
  {
    StatusCode = statusCode;
  }
}