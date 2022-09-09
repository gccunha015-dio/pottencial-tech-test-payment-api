[⬅️]

## Tarefas

<div align="center">

|⭕A fazer|✴️Fazendo|✅Feito|
|:-:|:-:|:-:|
|Definir modelo Venda||Rota com documentação swagger|
|Registrar venda||Definir modelo Vendedor|
|Buscar venda||Definir modelo Item|
|Atualizar venda||Definir modelo ItensDaVenda|

</div>

## Requisitos
- ✅Rota com documentação swagger
  - ✅Deve ser `http://.../api-docs`
- ✅Definir modelo Vendedor
  - ✅O vendedor deve possuir `id`, `cpf`, `nome`, `e-mail` e `telefone`
- ✅Definir modelo Item
  - ✅Contém `id`, `nome` e `preço unitario`
- ✅Definir modelo ItensDaVenda
  - ✅Contém `id da venda`, `id do item`, `quantidade do item`
- Definir modelo Venda
  - Uma venda contém informação sobre o `vendedor que a efetivou`, `data`, `identificador do pedido` e os `itens que foram vendidos`
  - Também contém `valor`
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