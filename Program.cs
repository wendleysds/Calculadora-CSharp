using System.Text.RegularExpressions;

namespace Calculator;

class Program
{
	public static void Main(string[] args)
	{
		Console.Write("> ");
		string? input = Console.ReadLine();

		try
		{
			Console.WriteLine(Calc(input));
		}
		catch (InvalidOperationException)
		{
			Console.WriteLine("Erro na expressão.");
		}
	}

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

	private static List<string> TokenizeExpression(string expression)
	{
		string pattern = @"([+\-*/()])|\s+";
		string[] tokens = Regex.Split(expression, pattern, RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);

		List<string> result = new();
		foreach (string token in tokens)
		{
			if (!string.IsNullOrWhiteSpace(token))
			{
				result.Add(token);
			}
		}

		return result;
	}

	private static float EvaluateExpression(List<string> tokens)
	{
		EvaluateParentheses(tokens);

		Dictionary<string, Func<float, float, float>> operators = new()
			{
				{ "*", (a, b) => a * b },
				{ "/", (a, b) => a / b },
				{ "+", (a, b) => a + b },
				{ "-", (a, b) => a - b }
			};

		while (tokens.Count > 1)
		{
			int operatorIndex = FindNextOperatorIndex(tokens, operators.Keys);
			float numA = ToFloat(tokens[operatorIndex - 1]);
			float numB = ToFloat(tokens[operatorIndex + 1]);
			float result = operators[tokens[operatorIndex]](numA, numB);
			tokens.RemoveRange(operatorIndex - 1, 3);
			tokens.Insert(operatorIndex - 1, result.ToString());
		}

		return ToFloat(tokens[0]);
	}

	private static void EvaluateParentheses(List<string> tokens)
	{
		while (tokens.Contains("("))
		{
			int openParenIndex = tokens.LastIndexOf("(");
			int closeParenIndex = tokens.FindIndex(openParenIndex, s => s.Equals(")"));

			if (openParenIndex != -1 && closeParenIndex != -1)
			{
				List<string> insideParentheses = tokens.GetRange(openParenIndex + 1, closeParenIndex - openParenIndex - 1);
				float result = EvaluateExpression(insideParentheses);
				tokens.RemoveRange(openParenIndex, closeParenIndex - openParenIndex + 1);
				tokens.Insert(openParenIndex, result.ToString());
			}
			else
			{
				throw new InvalidOperationException();
			}
		}
	}

	private static int FindNextOperatorIndex(List<string> tokens, IEnumerable<string> operators)
	{
		foreach (string op in operators)
		{
			int index = tokens.IndexOf(op);
			if (index != -1)
			{
				return index;
			}
		}
		throw new InvalidOperationException("Operador não encontrado.");
	}

	private static float ToFloat(string s) => Convert.ToSingle(s);
}