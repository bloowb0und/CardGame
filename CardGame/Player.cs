using System;
using System.Collections.Generic;

public class Player
{
	public string PlayerName
	{
		get; 
		set
		{
			if (value.Length != 0)
			{
				PlayerName = value;
			};
		} 
	}
	public Stack<Card> PlayerCards { get; set; }

	public Player(string name, Stack cards)
	{
		PlayerName = name;
		PlayerCards = cards;
	}
}
