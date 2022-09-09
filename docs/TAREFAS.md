[⬅️]

## Tarefas
| ⭕<br> A fazer | ✴️<br> Fazendo | ✅<br> Feito |
| - | - | - |
|Definir modelo Venda||Rota com documentação swagger|
|Definir modelo Vendedor|||
|Definir modelo Item|||
|Registrar venda|||
|Buscar venda|||
|Atualizar venda|||

## Requisitos
- Rota com documentação swagger
  - Deve ser `http://.../api-docs`
- Definir modelo Venda
  - Uma venda contém informação sobre o `vendedor que a efetivou`, `data`, `identificador do pedido` e os `itens que foram vendidos`
- Definir modelo Vendedor
  - O vendedor deve possuir `id`, `cpf`, `nome`, `e-mail` e `telefone`
- Registrar venda
  - Recebe os dados do vendedor + itens vendidos
  - Registra venda com status "Aguardando pagamento"
  - A inclusão de uma venda deve possuir pelo menos 1 item
- Buscar venda
  - Busca pelo Id da venda
- Atualizar venda
  - Permite que seja atualizado o status da venda
  - De: `Aguardando pagamento` Para: `Pagamento Aprovado`
  - De: `Aguardando pagamento` Para: `Cancelada`
  - De: `Pagamento Aprovado` Para: `Enviado para Transportadora`
  - De: `Pagamento Aprovado` Para: `Cancelada`
  - De: `Enviado para Transportador` Para: `Entregue`

[⬅️]

[⬅️]: ../README.md