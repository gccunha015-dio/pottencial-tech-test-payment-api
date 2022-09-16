namespace PaymentAPI.Helpers;

public class OperacaoInvalidaException : ApiException
{
  public OperacaoInvalidaException()
    : base(
        mensagem: "Operacao invalida.",
        status: StatusCodes.Status400BadRequest
    )
  { }
}