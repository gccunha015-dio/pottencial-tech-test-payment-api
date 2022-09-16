namespace PaymentAPI.Helpers;

public class IdInvalidoException : ApiException
{
  public IdInvalidoException()
    : base(
        mensagem: "Id invalido.",
        status: StatusCodes.Status404NotFound
    )
  { }
}