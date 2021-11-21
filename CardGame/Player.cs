using System;
using System.Collections;
using System.Collections.Generic;

public class Player
{
	private string _playerName;

	public string PlayerName
	{
		get => _playerName;
		set => _playerName = value;
	}

	public Stack<Card> PlayerCards { get; set; }

	public Player(string name, Stack<Card> cards)
	{
		PlayerName = name;
		PlayerCards = cards;
	}

	public Player(string name)
	{
		PlayerName = name;
		PlayerCards = new Stack<Card>();
	}
}
