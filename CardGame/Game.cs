﻿using System;
using System.Collections.Generic;

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
		List<int> usedIdxs = new List<int>();
		Random r = new Random();
		int card = 0;

		for (int i = 0; i < 36; i++)
		{
			do
			{
				card = r.Next(0, 36);
			} while (usedIdxs.Contains(card));

			usedIdxs.Add(card);
			ShuffledCards.Push(Cards[card]);
		}
		return ShuffledCards;
	}

	static void GiveCards(Stack<Card> shuffledCards)
	{
		for (int i = 0; i < 2; i++)
		{
			Players.Add(new Player("d"));
			for (int j = 0; j < 36 / 2; j++)
			{
				Players[i].PlayerCards.Push(shuffledCards.Pop());
			}
		}
	}
}
