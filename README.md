# C# Operações em Bits
Projeto trazendo resolução de problemas através de uso de bits de entrada, composto por algoritmos que geram informações oriundas destes bits.

## Situação e Origem do Problema
O submarino tem feito alguns ruídos estranhos, então pede-se o mesmo produza um relatório de diagnóstico, apenas por precaução. O relatório de diagnóstico (o dado de entrada) consiste em uma lista de números binários que, quando decodificados corretamente, podem trazer muitas informações úteis sobre as condições do submarino. O primeiro parâmetro a ser verificado é o consumo de energia. Logo, é necessário usar os números binários no relatório de diagnóstico para gerar dois novos números 
binários (chamados de taxa gama e taxa épsilon). O consumo de energia pode então ser encontrado multiplicando a taxa gama pela taxa épsilon.

```
00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010
```
Considerando apenas o primeiro bit de cada número, há cinco bits 0 e sete bits 1. Como o bit mais comum é 1, o primeiro bit da taxa gama é 1. O segundo bit mais comum dos números no relatório de diagnóstico é 0, então o segundo bit da taxa gama é 0. O valor mais comum dos bits terceiro, quarto e quinto são 1, 1 e 0, respectivamente, e assim, os três últimos bits da taxa gama são 110. Portanto, a taxa gama é o número binário 10110, ou 22 em decimal. A taxa épsilon é calculada de maneira semelhante; em vez de usar o bit mais comum, o bit menos comum de cada posição é utilizado. Assim, a taxa épsilon é 01001, ou 9 em decimal. Multiplicando a taxa gama (22) pela taxa épsilon (9) produz o consumo de energia, 198. Use os números binários no seu relatório de diagnóstico para calcular a taxa gama e a taxa épsilon e, 
em seguida, multiplique-os. Qual é o consumo de energia do submarino? (Certifique-se de representar a resposta em decimal, não em binário.

### Modelagem de software utilizada
O projeto 'Operações em Bits' foi desenvolvido se apropriando de conceitos sobre [Domain Driven Design](https://martinfowler.com/bliki/DomainDrivenDesign.html) como ponto de partida para modelagem de software com uso da [linguagem ubíqua](https://engsoftmoderna.info/artigos/ddd.html) e da segregação de camadas (para este projeto foram adotadas as camadas [Domínio e Aplicação](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)); em seguida foi utilizado o Padrão de Projeto [Factory](https://refactoring.guru/design-patterns/factory-method) para prover um objeto maleável de acordo com o tipo de taxa (a ser cálculada) optada pelo desenvolvedor para que realizasse o cálculo de bits mais comuns ou menos comuns.

----------------------
### Licença

[View MIT license](https://github.com/antonio-leonardo/OperacoesEmBits/blob/main/LICENSE)