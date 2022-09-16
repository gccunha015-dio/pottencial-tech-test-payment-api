namespace PaymentAPI.Data;

public interface IRepository<T>
{
  Task<T> LerPorId(uint id);
  Task Inserir(T value);
  Task Atualizar(T value);
}