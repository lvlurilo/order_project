# Contexto
Você deve implementar uma pequena API para gerenciar pedidos de uma loja online. O sistema deve permitir:
 - Criar um pedido com itens (produto, quantidade, preço unitário)
 - Calcular o valor total do pedido aplicando o desconto correto para o tipo do pedido
 - Atualizar a quantidade de um item no pedido
 - Remover um item do pedido
 - Obter o resumo do pedido (itens + valor total com desconto aplicado)

# Entrega
 - Crie um repositório público no GitHub com o código desenvolvido.
 - Compartilhe o link do repositório para avaliação.

# Requisitos técnicos

## Tipos de pedido e regras de desconto
Cada pedido possui um tipo que determina como o valor total é calculado:

| Tipo | Regra |
|---|---|
| `standard` | Sem desconto |
| `express` | Acréscimo de 15% (taxa de entrega rápida) |
| `subscription` | Desconto de 10% (cliente assinante) |

O valor total deve sempre refletir a regra do tipo do pedido.

## Arquitetura
 - Separe as responsabilidades em camadas (ex: Controllers, Services, Repositories, Models/Entities, DTOs).
 - Use interfaces para abstrair dependências.
 - Aplique pelo menos um design pattern relevante (ex: Repository, Factory, Strategy).
 - Utilize banco de dados em memória (ex: H2, SQLite in-memory).

## Clean Code
 - Código legível e organizado.
 - Nomes claros para classes, métodos e variáveis.
 - Métodos pequenos e focados.
 - Tratamento básico de erros.

## Testes
 - Implemente testes unitários para a camada de serviço.
 - Teste pelo menos os casos: criação de pedido `standard`, `express` e `subscription`, cálculo do total com desconto correto, atualização e remoção de itens.
 - Implemente validações.

# Exemplo simplificado do fluxo esperado
POST /orders
    Corpo: tipo do pedido + lista de itens (produto, quantidade, preço)
    Retorno: ID do pedido criado

PUT /orders/{orderId}/items/{itemId}
    Atualiza a quantidade do item

DELETE /orders/{orderId}/items/{itemId}
    Remove o item do pedido

GET /orders/{orderId}
    Retorna o resumo do pedido com valor total calculado e desconto aplicado
