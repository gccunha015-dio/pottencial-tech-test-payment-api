[Voltar]

## Tarefas
Legenda:
- ✅: feito
- ✴️: fazendo
- ❌: nao iniciado

<table>
  <thead>
    <tr>
      <th>Tarefa</th>
      <th>Status</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>A API deve expor uma rota com documentação swagger (http://.../api-docs).</td>
      <td>✅</td>
    </tr>
    <tr>
      <td>A API deve possuir 3 operações:
        <ol>
          <li>Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento";</li>
          <li>Buscar venda: Busca pelo Id da venda;</li>
          <li>Atualizar venda: Permite que seja atualizado o status da venda.
            <ul><li>OBS.: Possíveis status: Pagamento aprovado, Enviado para transportadora, Entregue, Cancelada.</li></ul>
          </li>
        </ol>
      </td>
      <td>
        <ol>
          <li>✴️</li>
          <li>✅</li>
          <li>❌</li>
        </ol>
      </td>
    </tr>
    <tr>
      <td>Uma venda contém informação sobre o vendedor que a efetivou, data, identificador do pedido e os itens que foram vendidos;</td>
      <td>✅</td>
    </tr>
    <tr>
      <td>O vendedor deve possuir id, cpf, nome, e-mail e telefone;</td>
      <td>✅</td>
    </tr>
    <tr>
      <td>A inclusão de uma venda deve possuir pelo menos 1 item;</td>
      <td>✅</td>
    </tr>
    <tr>
      <td>A atualização de status deve permitir somente as seguintes transições:
        <ol>
          <li>De: Aguardando pagamento Para: Pagamento Aprovado</li>
          <li>De: Aguardando pagamento Para: Cancelada</li>
          <li>De: Pagamento Aprovado Para: Enviado para Transportadora</li>
          <li>De: Pagamento Aprovado Para: Cancelada</li>
          <li>De: Enviado para Transportador. Para: Entregue</li>
        </ol>
      </td>
      <td>
        <ol>
          <li>❌</li>
          <li>❌</li>
          <li>❌</li>
          <li>❌</li>
          <li>❌</li>
        </ol>
      </td>
    </tr>
  </tbody>
  <tfoot>
    <tr>
      <td>Outras validacoes do vendedor
        <ol>
          <li>CPF deve ter 11 digitos</li>
          <li>CPF deve ter somente numeros</li>
          <li>Email deve passar pela RegEx `\w+@\w+\.[a-z]{2,3}`</li>
        </ol>
      </td>
      <td>
        <ol>
          <li>✅</li>
          <li>❌</li>
          <li>❌</li>
        </ol>
      </td>
    </tr>
    <tr>
      <td>Separar instanciacao dos Itens e do Vendedor da Venda</td>
      <td>✴️</td>
    </tr>
    <tr>
      <td>Melhorar organizaca do codigo e das responsabilidades</td>
      <td>❌</td>
    </tr>
  </tfoot>
</table>

[Voltar]

[Voltar]: ../README.md