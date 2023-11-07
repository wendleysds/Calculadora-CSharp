# Calculadora-Avancada-CSharp
Calculadora capaz de interpretar uma expressão matemática contendo soma, subtração, divisão e multiplicação, seguindo o PEMDAS(Parênteses, Exponenciação, Multiplicação, Adição, Subtração).

Este é um código C# que implementa uma calculadora capaz de ler expressões matemáticas. Vou explicar as principais partes do código:

1. **Método `Calc`**:
   ```csharp
   private static float Calc(string input)
   {
       try
       {
           List<string> c = SplitStringIntoChar(input);
           return HandleExpression(HandleParen(c));
       }
       catch (Exception)
       {
           throw new InvalidOperationException();
       }
   }
   ```
   O método `Calc` é responsável por calcular o resultado da expressão matemática. Ele faz isso em três passos:
   - Primeiro, ele divide a expressão em uma lista de caracteres (`List<string> c`) usando o método `SplitStringIntoChar`.
   - Em seguida, ele trata os parênteses chamando o método `HandleParen`.
   - Por fim, ele calcula a expressão usando o método `HandleExpression`.

2. **Método `SplitStringIntoChar`**:
   ```csharp
   private static List<string> SplitStringIntoChar(string n)
   {
       // ...
   }
   ```
   Este método converte a expressão em uma lista de caracteres. Ele percorre a string caractere por caractere e identifica operadores matemáticos (+, -, *, /) e parênteses.

`Entrada:` string = "20 + 4 - (5 * 3) / 3" <br>
`Saida:` List(string) = { "20", "+", "4", "-", "(", "5", "*", "3", ")", "/", "3" }

3. **Método `HandleParen`**:
   ```csharp
   private static List<string> HandleParen(List<string> data)
   {
       // ...
   }
   ```
   Este método lida com os parênteses na expressão. Ele percorre a lista de caracteres e, quando encontra um par de parênteses correspondentes, calcula a expressão dentro deles.

`Entrada:` List(string) = { "20", "+", "4", "-", "(", "5", "*", "3", ")", "/", "3" } <br>
`Saida:` List(string) = { "20", "+", "4", "-", "15", "/", "3" } => `20 + 4 - 15 / 3`

4. **Método `HandleExpression`**:
   ```csharp
   private static float HandleExpression(List<string> data)
   {
       // ...
   }
   ```
   Este método trata as operações na expressão (adição, subtração, multiplicação e divisão) em ordem de precedência. Ele utiliza um loop para iterar sobre a lista de caracteres e realiza as operações conforme necessário.

`Entrada:` List(string) = { "20", "+", "4", "-", "15", "/", "3" } <br>
`Saida:` float = 19

5. **Métodos Auxiliares**:
   - `RemoveItens`: Remove um determinado número de itens de uma lista a partir de uma posição específica.
   - `Result`: Calcula o resultado de uma operação entre dois números.
   - `ToFloat` Converte uma string em float.

Esse código implementa uma calculadora que é capaz de avaliar expressões matemáticas simples, levando em consideração a precedência dos operadores e o uso de parênteses. Por exemplo, ela pode avaliar expressões como `3 + (4 * 2)`, que resultaria em `11`, ou `24 / 4 + 5 - 4 * (5+2+(24 / 4) - 2)` que resultaria em `-33`
