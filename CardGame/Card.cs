using System;

public class Card
{
	public string CardSuit { get; set; }
	public int CardType { get; set; }

	public Card(string suit, int type)
	{
		CardSuit = suit;
		CardType = type;
	}
}
