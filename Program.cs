namespace Calculator;

class Program
{
	public static void Main(string[] args)
	{
		string input = Console.ReadLine();

		Console.WriteLine(Calc(input));
	}

	private static float Calc(string input)
	{
		try{
			List<string> c = SplitStringIntoChar(input);
			return HandleExpression(HandleParen(c));
		}catch(Exception){ throw new InvalidOperationException(); }
	}

	private static List<string> HandleParen(List<string> data)
	{
		do
		{
			int parenStart = -1;
			int parenEnd = -1;

			int c = 0;
			foreach (string s in data)
			{
				if (s.Equals("("))
				{
					parenStart = c;
				}
				if (s.Equals(")") && parenEnd == -1)
				{
					parenEnd = c;
				}
				c++;
			}

			if (!parenStart.Equals(-1) && !parenEnd.Equals(-1))
			{
				List<string> parenData = new();

				for (int i = parenStart + 1; i < parenEnd; i++)
				{
					parenData.Add(data[i]);
				}

				int parenDataSize = parenData.Count;

				HandleExpression(parenData);

				RemoveItens(ref data, parenStart, parenDataSize + 1);

				data[parenStart] = HandleExpression(parenData).ToString();

				continue;
			}
			else 
				break; 

		}while (true);

		return data;
	}

	private static float HandleExpression(List<string> data)
	{
		int interations = 7;

		float numA, numB;
		float r;

		while (interations > 0)
		{
			int divideOpIndex = -1;
			int multiplyOpIndex = -1;
			int addOpIndex = -1;
			int subOpIndex = -1;

			if (data.Contains("/"))
			{
				divideOpIndex = data.IndexOf("/");
			}

			if (data.Contains("*"))
			{
				multiplyOpIndex = data.IndexOf("*");
			}
			if (data.Contains("+"))
			{
				addOpIndex = data.IndexOf("+");
			}
			if (data.Contains("-"))
			{
				subOpIndex = data.IndexOf("-");
			}

			if (divideOpIndex < multiplyOpIndex && divideOpIndex != -1)
			{
				goto Div;
			}
			else
			{
				if (multiplyOpIndex != -1)
					goto Mult;

				if (divideOpIndex != -1)
					goto Div;
			}

			if (addOpIndex != -1)
				goto Add;
			if (subOpIndex != -1)
				goto Sub;

			if (data.Count == 1) break;

			interations--;

			continue;

		Add:
			numA = ToFloat(data[addOpIndex - 1]);
			numB = ToFloat(data[addOpIndex + 1]);
			r = Result(numA, numB, data[addOpIndex]);
			RemoveItens(ref data, addOpIndex - 1, 2);
			data[addOpIndex - 1] = r.ToString();
			continue;
		Sub:
			numA = ToFloat(data[subOpIndex - 1]);
			numB = ToFloat(data[subOpIndex + 1]);
			r = Result(numA, numB, data[subOpIndex]);
			RemoveItens(ref data, subOpIndex - 1, 2);
			data[subOpIndex - 1] = r.ToString();
			continue;
		Div:
			numA = ToFloat(data[divideOpIndex - 1]);
			numB = ToFloat(data[divideOpIndex + 1]);
			r = Result(numA, numB, data[divideOpIndex]);
			RemoveItens(ref data, divideOpIndex - 1, 2);
			data[divideOpIndex - 1] = r.ToString();
			continue;
		Mult:
			numA = ToFloat(data[multiplyOpIndex - 1]);
			numB = ToFloat(data[multiplyOpIndex + 1]);
			r = Result(numA, numB, data[multiplyOpIndex]);
			RemoveItens(ref data, multiplyOpIndex - 1, 2);
			data[multiplyOpIndex - 1] = r.ToString();
			continue;
		}

		return ToFloat(data[0]);
	}

	private static void RemoveItens(ref List<string> list, int itemIndex, int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			list.RemoveAt(itemIndex);
		}
	}

	private static float Result(float a, float b, string op)
	{
        return op switch
        {
            "+" => a + b,
            "-" => a - b,
            "/" => a / b,
            "*" => a * b,
            _ => 0,
        };
    }

	private static List<string> SplitStringIntoChar(string n)
	{
		List<string> characters = new();

		string r = "";

		bool breakLine = false;

		foreach (char c in n)
		{
			if (!c.Equals(' '))
			{
				switch (c)
				{
					case '+': breakLine = true; break;
					case '-': breakLine = true; break;
					case '/': breakLine = true; break;
					case '*': breakLine = true; break;
					case '(': breakLine = true; break;
					case ')': breakLine = true; break;
				}

				if (breakLine)
				{
					if (!r.Equals(""))
						characters.Add(r);

					characters.Add(c.ToString());
					r = "";
					breakLine = false;
					continue;
				}
				r += c;
			}
		}

		characters.Add(r);

		return characters;
	}

	private static float ToFloat(string s) { return Convert.ToSingle(s); }
}