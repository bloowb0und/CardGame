using System;
using System.Collections.Generic;
using CardGame;

public static class Game
{
	public static List<Player> Players { get; set; }
	public static List<Card> Cards { get; set; }

	static Game()
	{
		Players = new List<Player>();
		Cards = new List<Card>();

		string suit;
		for (int i = 0; i < 4; i++)
		{
			if (i == 0)
			{
				suit = "pika";
			}
			else if (i == 1)
			{
				suit = "kresta";
			}
			else if (i == 2)
			{
				suit = "cherva";
			}
			else
			{
				suit = "bubna";
			}
			for (int j = 6; j <= 14; j++)
			{
				Cards.Add(new Card(suit, j));
			}
		}
		Stack<Card> ShuffledCards = ShuffleCards();
		GiveCards(ShuffledCards);
	}

	static Stack<Card> ShuffleCards()
	{
		Stack<Card> ShuffledCards = new Stack<Card>();
		List<int> usedCards = new List<int>();
		Random r = new Random();
		int card = 0;

		for (int i = 0; i < 36; i++)
		{
			do
			{
				card = r.Next(0, 36);
			} while (usedCards.Contains(card));

			usedCards.Add(card);
			ShuffledCards.Push(Cards[card]);
		}
		return ShuffledCards;
	}

	static void GiveCards(Stack<Card> shuffledCards)
	{
		for (int i = 0; i < PlayerSettings.AmountOfPlayers; i++)
		{
			Players.Add(new Player(PlayerSettings.PlayerNames[i]));
			for (int j = 0; j < 36 / PlayerSettings.AmountOfPlayers; j++)
			{
				Players[i].PlayerCards.Push(shuffledCards.Pop());
			}
		}
	}
}
