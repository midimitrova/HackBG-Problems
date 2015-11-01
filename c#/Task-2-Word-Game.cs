using System;

public static class GlobalMembersTaskMinus2MinusWordMinusGame
{

	// Global variables
	public const int SIZE_ARRAY = 20;
	public const int SIZE_WORD = 30;
	public static bool way = false;
	public static short counter = 0;


	public static bool labyrinth(int i, int j, string[] arr, short n, short m, string word, short len_word)
	{
		if (arr[i, j] != word[0])
		{
			return false;
		}

		if (i < 0 || i> n - 1 || j < 0 || j> m - 1)
		{
			return false;
		} // If it's out of range

		if (len_word < 1)
		{
			return false;
		} // Just in case

		if (word[0] == '\0')
		{
			return false;
		} // Just in case

		if (len_word == 1 && arr[i, j] == word[0]) // If it finds the word in the array
		{
			way = true;
			++counter; // Counter accumulate, how many times it finds the word in the array
		}


		if (i >= 0 && i <= n - 1 && j >= 0 && j <= m - 1)
		{
			return (labyrinth(i - 1, j, arr, n, m, word + 1, len_word - 1) || labyrinth(i + 1, j, arr, n, m, word + 1, len_word - 1) || labyrinth(i, j + 1, arr, n, m, word + 1, len_word - 1) || labyrinth(i, j - 1, arr, n, m, word + 1, len_word - 1)); // Left -  Right -  Down -  Up
		}

		return false; // Just in case
	}

	public static void print_labyrinth(string[] arr, short n, short m)
	{
		for (int i = 0; i < n; ++i)
		{
			Console.Write("\n");
			for (int j = 0; j < m; ++j)
			{
				Console.Write(arr[i, j]);
				Console.Write(" ");
			}
		}
	}

	public static void Example()
	{
		sbyte[,] Array =
		{
			{'i', 'v', 'a', 'n'},
			{'e', 'v', 'n', 'h'},
			{'i', 'n', 'a', 'v'},
			{'m', 'v', 'v', 'n'},
			{'q', 'r', 'i', 't'}
		}; // N x M

		short n = 5; // Rows
		short m = 4; // Colums

		string word = "ivan";
		short len_word = word.Length;

		Console.Write("\n---> Default Array: \n");
		print_labyrinth(Array, n, m);

		Console.Write("\n\n---> Default word: ");
		Console.Write(word);
		Console.Write("\n");

		for (int i = 0; i < n; ++i)
		{
			for (int j = 0; j < m; ++j)
			{
				if (Array[i, j] == word[0])
				{
					labyrinth(i, j, Array, n, m, word, len_word);
				}
			}
		}

	}

	public static void Submit_your_values()
	{
		string Array = "";
		int n;
		int m;

		do
		{
			Console.Write("\n---> Enter:  (Rows x Columns) = (n x m)  \n");
			Console.Write("n= ");
			n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			Console.Write("m= ");
			m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
		} while (n < 1 || n > SIZE_ARRAY || n < 1 || n > SIZE_ARRAY);

		Console.Write("\n---> Enter Array: \n");
		for (int i = 0; i < n; ++i)
		{
		for (int j = 0; j < m; ++j)
		{
		{
			Array[i][j] = ConsoleInput.ReadToWhiteSpace(true);
	}
		}

		Console.Write("\n---> You entered: \n");
		print_labyrinth(Array, n, m);

		Console.Write("\n\n---> Enter the word you find: \n");
		string word = "\0";
		Console.Write("word= ");
		word = sbyte.Parse(ConsoleInput.ReadToWhiteSpace(true));

		short len_word = word.Length;

		for (int i = 0; i < n; ++i)
		{
			for (int j = 0; j < m; ++j)
			{
				if (Array[i][j] == word[0])
				{
					labyrinth(i, j, Array, n, m, word, len_word);
				}
			}
		}
		}

	public static void Result()
	{
		if (way)
		{
			Console.Write("\n\n---> Success: the number of words: ");
			Console.Write(counter);
			Console.Write("\n");
		}
		else
		{
			Console.Write("\n\n---> NO Results !\n");
		}
	}


	public static void Introduction()
	{
		Console.Write("\t\t\t\tWord Game:\n");
		Console.Write("Enter '1' for use the example\n");
		Console.Write("\t or\n");
		Console.Write("Enter '2' for use your values\n");
		short entered;
		do
		{
			entered = short.Parse(ConsoleInput.ReadToWhiteSpace(true));

		} while (entered != 1 && entered != 2);

		if (entered == 1)
		{
			Example();
		}
		else
		{
			Submit_your_values();
		}
	}

	static int Main()
	{

		Introduction();

		Result();

		return 0;
	}
	}

