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
	public Stack<Card> PlayerWonCards { get; set; }


	public Player(string name, Stack<Card> cards)
	{
		PlayerName = name;
		PlayerCards = cards;
		PlayerWonCards = new Stack<Card>();
	}

	public Player(string name)
	{
		PlayerName = name;
		PlayerCards = new Stack<Card>();
		PlayerWonCards = new Stack<Card>();
	}
}
