namespace PaymentAPI.Helpers;

public class ApiException : Exception
{
  public int Status { get; set; }
  public ApiException(string mensagem, int status) : base(mensagem)
  {
    Status = status;
  }
}