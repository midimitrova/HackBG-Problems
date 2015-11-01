using System;

public static class GlobalMembersSource
{


	static int Main()
	{
		Console.Write("Starting point: ");
		string startPosStr;
		string movement;
		startPosStr = Console.ReadLine();
		movement = Console.ReadLine();
		uint digitsProcessed;
		int startX = stoi(startPosStr.Substring(1), digitsProcessed);
		int startY = Convert.ToInt32(startPosStr.Substring(digitsProcessed + 3));
		int direction = 1;
		for (int i = 0; i < movement.Length; i++)
		{
			switch (movement[i])
			{
			case '>':
				startX += direction;
				break;
			case '<':
				startX -= direction;
				break;
			case '^':
				startY -= direction;
				break;
			case 'v':
				startY += direction;
				break;
			case '~':
				direction *= -1;
			break;
			}
		}
		Console.Write("(");
		Console.Write(startX);
		Console.Write(", ");
		Console.Write(startY);
		Console.Write(")");
		Console.Write("\n");
		return 0;
	}
}

