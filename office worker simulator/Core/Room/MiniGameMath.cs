using System;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace office_worker_simulator.Core.Room;

public class MiniGameMath : IMiniGame
{
	public string Title => "Решить пример";
	public string Text { get; private set; }
	public int Answer { get; private set; }
	public bool IsPlayerFinishedEnteringData { get; set; }

	private readonly Random randomNumber1 = new();
	private readonly Random randomNumber2 = new();
	private readonly Random randomOperator = new();


	public void Start()
	{
		var number1 = randomNumber1.Next(1, 100);
		var number2 = randomNumber2.Next(1, 100);
		string operatorSign;
		switch (randomOperator.Next(3))
		{
			case 0:
				operatorSign = "+";
				Answer = number1 + number2;
				break;
			case 1:
				operatorSign = "-";
				if (number2 > number1)
					(number1, number2) = (number2, number1);
				Answer = number1 - number2;
				break;
			case 2:
				operatorSign = "*";
				number1 = number1 > 10 ? number1 % 10 : number1;
				number2 = number2 > 10 ? number2 % 10 : number2;
				Answer = number1 * number2;
				break;
			default:
				throw new ArgumentOutOfRangeException("MiniGameMath: randomOperator.Next(3)");
		}

		Text = $"{number1} {operatorSign} {number2} = ???";
		
	}
	
	public object PlayerInput => sb.ToString();
	private readonly StringBuilder sb = new StringBuilder();

	public void Input()
	{
		var state = Keyboard.GetState();

		foreach (var key in state.GetPressedKeys().Where(x => x is >= Keys.D0 and <= Keys.D9 or Keys.Back))
			switch (key)
			{
				case Keys.Back:
				{
					if (sb.Length > 0)
						sb.Remove(sb.Length - 1, 1);
					break;
				}
				case Keys.D1:
					sb.Append('1');
					break;
				case Keys.D2:
					sb.Append('2');
					break;
				case Keys.D3:
					sb.Append('3');
					break;
				case Keys.D4:
					sb.Append('4');
					break;
				case Keys.D5:
					sb.Append('5');
					break;
				case Keys.D6:
					sb.Append('6');
					break;
				case Keys.D7:
					sb.Append('7');
					break;
				case Keys.D8:
					sb.Append('8');
					break;
				case Keys.D9:
					sb.Append('9');
					break;
				case Keys.D0:
					sb.Append('0');
					break;
			}
		Console.WriteLine(Text);
		Console.WriteLine(PlayerInput);
	}
}