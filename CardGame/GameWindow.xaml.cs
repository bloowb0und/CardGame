using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CardGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        ImageSourceConverter imageSourceConverter = new ImageSourceConverter();

        private bool firstGame = true;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnGameWindow_Loaded(object sender, RoutedEventArgs e)
        {
			PlayerSettings.CurrentPlayerIdx = 0;
			PlayerSettings.roundCards = new Card[PlayerSettings.AmountOfPlayers];

			if (!firstGame)
            {
                PlayerSettings.ControlPlayersImagesList = new List<Image>();
                PlayerSettings.ControlPlayersNamesList = new List<Label>();
                PlayerSettings.ControlPlayersCardImagesList = new List<Image>();
            }

            if (PlayerSettings.AmountOfPlayers >= 2)
            {
                PlayerSettings.ControlPlayersImagesList.Add(this.Player1Image);
                PlayerSettings.ControlPlayersNamesList.Add(this.Player1Name);
                PlayerSettings.ControlPlayersCardImagesList.Add(this.Player1Card);
                
                PlayerSettings.ControlPlayersImagesList.Add(this.Player2Image);
                PlayerSettings.ControlPlayersNamesList.Add(this.Player2Name);
                PlayerSettings.ControlPlayersCardImagesList.Add(this.Player2Card);
                
                PlayerSettings.ControlPlayersNamesList.Add(this.Player3Name);
                PlayerSettings.ControlPlayersCardImagesList.Add(this.Player3Card);
                PlayerSettings.ControlPlayersImagesList.Add(this.Player3Image);
                
                PlayerSettings.ControlPlayersNamesList.Add(this.Player4Name);
                PlayerSettings.ControlPlayersCardImagesList.Add(this.Player4Card);
                PlayerSettings.ControlPlayersImagesList.Add(this.Player4Image);
                
                PlayerSettings.ControlPlayersNamesList.Add(this.Player5Name);
                PlayerSettings.ControlPlayersCardImagesList.Add(this.Player5Card);
                PlayerSettings.ControlPlayersImagesList.Add(this.Player5Image);
                        
                PlayerSettings.ControlPlayersNamesList.Add(this.Player6Name);
                PlayerSettings.ControlPlayersCardImagesList.Add(this.Player6Card);
                PlayerSettings.ControlPlayersImagesList.Add(this.Player6Image);
            }

            int amountOfCardsForEach = 36 / PlayerSettings.AmountOfPlayers;
            
            LblCurrentTurn.Content = PlayerSettings.PlayerNames[0];
            
            for (int i = 0; i < 6; i++)
            {
                PlayerSettings.ControlPlayersImagesList[i].Stretch = Stretch.Fill;
                PlayerSettings.ControlPlayersImagesList[i].Width = 70;
                PlayerSettings.ControlPlayersImagesList[i].Height = 130;
                
                if (i+1 <= PlayerSettings.AmountOfPlayers)
                {
                    PlayerSettings.ControlPlayersImagesList[i].Source = new BitmapImage(PlayerSettings.PlayerPictureURLs[i]);
                    PlayerSettings.ControlPlayersNamesList[i].Content = PlayerSettings.PlayerNames[i] + $"({amountOfCardsForEach})";
                    PlayerSettings.ControlPlayersCardImagesList[i].Source = null;
                }
                else
                {
                    PlayerSettings.ControlPlayersImagesList[i].Source = (ImageSource) imageSourceConverter.ConvertFrom("../../Images/emptySeat.png");
                    PlayerSettings.ControlPlayersImagesList[i].Width = 100;
                    if (i == 5)
                        PlayerSettings.ControlPlayersImagesList[i].Margin = new Thickness(120, 0, 0, 0);
                    PlayerSettings.ControlPlayersNamesList[i].Visibility = Visibility.Hidden;
                    PlayerSettings.ControlPlayersCardImagesList[i].Visibility = Visibility.Collapsed;
                }
            }
        }

        private void BtnNextTurn_Click(object sender, RoutedEventArgs e)
        {
			//if (PlayerSettings.CurrentPlayerIdx == PlayerSettings.AmountOfPlayers - 1)
			//{
			//	PlayerSettings.ControlPlayersNamesList[PlayerSettings.CurrentPlayerIdx + 1].Foreground = Brushes.Red;
			//}
			//else
			//{
			//	for (int i = 0; i < PlayerSettings.AmountOfPlayers; i++)
			//	{
			//		if (i == PlayerSettings.CurrentPlayerIdx)
			//		{
			//			PlayerSettings.ControlPlayersNamesList[i + 1].Foreground = Brushes.Red;
			//		}
			//		else
			//		{
			//			PlayerSettings.ControlPlayersNamesList[i].Foreground = Brushes.White;
			//		}
			//	}
			//}

			if (PlayerSettings.CurrentPlayerIdx == PlayerSettings.AmountOfPlayers)
			{
				PlayerSettings.CurrentPlayerIdx = 0;
				Array.Clear(PlayerSettings.roundCards, 0, PlayerSettings.AmountOfPlayers);

				foreach (Image cardImage in PlayerSettings.ControlPlayersCardImagesList)
				{
					cardImage.Visibility = Visibility.Collapsed;
				}

				foreach (Label player in PlayerSettings.ControlPlayersNamesList)
				{
					player.Foreground = Brushes.White;
				}
				PlayerSettings.ControlPlayersNamesList[PlayerSettings.CurrentPlayerIdx + 1].Foreground = Brushes.Red;
			}
			else
			{
				foreach (Label player in PlayerSettings.ControlPlayersNamesList)
				{
					player.Foreground = Brushes.White;
				}
				PlayerSettings.ControlPlayersNamesList[PlayerSettings.CurrentPlayerIdx + 1].Foreground = Brushes.Red;

				if (PlayerSettings.CurrentPlayerIdx == PlayerSettings.AmountOfPlayers - 1)
				{
					PlayerSettings.ControlPlayersNamesList[0].Foreground = Brushes.Red;
				}
			}

			this.LblCurrentTurn.Content = Game.Players[PlayerSettings.CurrentPlayerIdx].PlayerName;

            if (Game.Players[PlayerSettings.CurrentPlayerIdx].PlayerCards.Count == 0)
            {
                //no cards left
                return;
            }

            PlayerSettings.roundCards[PlayerSettings.CurrentPlayerIdx] = Game.Players[PlayerSettings.CurrentPlayerIdx].PlayerCards.Pop();

            //add card image
            PlayerSettings.ControlPlayersCardImagesList[PlayerSettings.CurrentPlayerIdx].Source =
				(ImageSource) imageSourceConverter.ConvertFrom($"../../Images/Cards/{PlayerSettings.roundCards[PlayerSettings.CurrentPlayerIdx].CardSuit}_{PlayerSettings.roundCards[PlayerSettings.CurrentPlayerIdx].CardType}.JPG");

            PlayerSettings.ControlPlayersCardImagesList[PlayerSettings.CurrentPlayerIdx].Visibility = Visibility.Visible;

            //change cards amount
            PlayerSettings.ControlPlayersNamesList[PlayerSettings.CurrentPlayerIdx].Content = 
                $"{Game.Players[PlayerSettings.CurrentPlayerIdx].PlayerName} ({Game.Players[PlayerSettings.CurrentPlayerIdx].PlayerCards.Count})";

            //last player
            if (PlayerSettings.CurrentPlayerIdx == PlayerSettings.AmountOfPlayers - 1)
            {
                Card maxCardValue = PlayerSettings.roundCards[0];
                int playerIdx = 0;

                for (int i = 0; i < PlayerSettings.AmountOfPlayers; i++)
                {
                    if (maxCardValue.CardType < PlayerSettings.roundCards[i].CardType)
                    {
                        maxCardValue.CardType = PlayerSettings.roundCards[i].CardType;
                        playerIdx = i;
                    }
                }
                foreach (Card card in PlayerSettings.roundCards)
                {
                    Game.Players[playerIdx].PlayerCards.Push(card);
                }
				
                //change amount
                PlayerSettings.ControlPlayersNamesList[playerIdx].Content = 
                    $"{Game.Players[playerIdx].PlayerName} ({Game.Players[playerIdx].PlayerCards.Count})";


                if (Game.Players[playerIdx].PlayerCards.Count == 36)
                {
                    //player won
                }

                //hide cards
            }
            //next player turns
            PlayerSettings.CurrentPlayerIdx++;
		}
	}
}