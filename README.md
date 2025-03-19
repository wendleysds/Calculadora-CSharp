# Calculadora-CSharp
Calculadora capaz de interpretar uma expressão matemática contendo soma, subtração, divisão e multiplicação, seguindo o PEMDAS(Parênteses, Exponenciação, Multiplicação, Adição, Subtração).

Principais partes do código:

1. **Método `Calc`**:
   ```csharp
   private static float Calc(string input)
	{
		try
		{
			return EvaluateExpression(TokenizeExpression(input));
		}
		catch (Exception)
		{
			throw new InvalidOperationException();
		}
	}
   ```
   O método `Calc` é responsável por calcular o resultado da expressão matemática. Ele faz isso em três passos:
   - Primeiro, ele divide a expressão em tokens e armazena em uma lista de caracteres atraves do método `TokenizeExpression`.
   - E por fim, ele calcula a expressão usando o método `EvaluateExpression`.

2. **Método `SplitStringIntoChar`**:
   ```csharp
   private static List<string> TokenizeExpression(string expression)
   {
       // ...
   }
   ```
   Este método converte a expressão em uma lista de tokens. Ele percorre a string caractere por caractere e identifica operadores matemáticos (+, -, *, /) e parênteses.

`Entrada:` string = "20 + 4 - (5 * 3) / 3" <br>
`Saida:` List(string) = { "20", "+", "4", "-", "(", "5", "*", "3", ")", "/", "3" }

3. **Método `EvaluateParentheses`**:
   ```csharp
   private static void EvaluateParentheses(List<string> tokens)
   {
       // ...
   }
   ```
   Este método lida com os parênteses na expressão. Ele percorre a lista de caracteres e, quando encontra um par de parênteses correspondentes, calcula a expressão dentro deles.

`Entrada:` List(string) = { "20", "+", "4", "-", "(", "5", "*", "3", ")", "/", "3" } <br>
`Saida:` List(string) = { "20", "+", "4", "-", "15", "/", "3" } => `20 + 4 - 15 / 3`

4. **Método `EvaluateExpression`**:
   ```csharp
   private static float EvaluateExpression(List<string> tokens)
   {
       // ...
   }
   ```
   Este método trata as operações na expressão (adição, subtração, multiplicação e divisão) em ordem de precedência. Ele utiliza um loop para iterar sobre a lista de tokens e realiza as operações atraves do `Dictionary operators`.

`Entrada:` List(string) = { "20", "+", "4", "-", "15", "/", "3" } <br>
`Saida:` float = 19

5. **Métodos Auxiliares**:
   - `FindNextOperatorIndex`: Encontra o operador mais proximo seguindo o PEMDAS.
   - `ToFloat` Converte uma string em float.

**Exemplo de entrada e saida**: 
   - entrada: `3 + (4 * 2)`, saida: `11`
   - entrada: `24 / 4 + 5 - 4 * (5 + 2 + (24 / 4) - 2)`, saida: `-33`
