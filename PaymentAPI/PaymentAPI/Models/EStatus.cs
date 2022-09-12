using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models;

public enum EStatus
{
  AGUARDANDO_PAGAMENTO,
  PAGAMENTO_APROVADO,
  ENVIADO_PARA_TRANSPORTADORA,
  ENTREGUE,
  CANCELADA
}

public class EStatusDTO
{
  [Required]
  public EStatus Status { get; set; }
}