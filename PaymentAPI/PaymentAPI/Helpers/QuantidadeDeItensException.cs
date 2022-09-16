namespace PaymentAPI.Helpers;

public class QuantidadeDeItensException : ApiException
{
  public QuantidadeDeItensException()
    : base(
        mensagem: "A inclusão de uma venda deve possuir pelo menos 1 item.",
        status: StatusCodes.Status422UnprocessableEntity
    )
  { }
}