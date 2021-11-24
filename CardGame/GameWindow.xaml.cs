using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace CardGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
		private bool firstGame = true;
		private int NextPlIdx = -1;

		public MainWindow()
        {
            InitializeComponent();
            
            this.Hide();
            var addPlayerWindow = new AddPlayerWindow();
            addPlayerWindow.Closed += (s, args) =>
            {
	            if(addPlayerWindow.IsStarted)
		            this.Show();
	            else
		            this.Close();
            }; 
            addPlayerWindow.Show();
        }

        private void OnGameWindow_Loaded(object sender, RoutedEventArgs e)
        {
	        PlayerSettings.CurrPlIdx = -1;
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
            
            LblLeader.Content = " * ";
            
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
                    PlayerSettings.ControlPlayersNamesList[i].Visibility = Visibility.Hidden;
                    PlayerSettings.ControlPlayersCardImagesList[i].Visibility = Visibility.Collapsed;
                }
            }

			if (PlayerSettings.AmountOfPlayers == 2)
			{
				PlayerSettings.ControlPlayersCardImagesList[2].Visibility = Visibility.Collapsed;
				PlayerSettings.ControlPlayersCardImagesList[3].Visibility = Visibility.Collapsed;
			}
		}

        private void BtnNextTurn_Click(object sender, RoutedEventArgs e)
        {
			var converter = new System.Windows.Media.BrushConverter();

			//check end of round
			if (NextPlIdx == PlayerSettings.AmountOfPlayers)
			{
				// check round winner
				Card maxCardValue = null;
				int playerWinIdx = -1;

				for (int i = 0; i < PlayerSettings.AmountOfPlayers; i++)
				{
					if (PlayerSettings.roundCards[i] == null)
					{
						continue;
					}
					if (maxCardValue == null)
					{
						maxCardValue = PlayerSettings.roundCards[i];
						playerWinIdx = i;
					}
					if (maxCardValue.CardType < PlayerSettings.roundCards[i].CardType)
					{
						maxCardValue = PlayerSettings.roundCards[i];
						playerWinIdx = i;
					}
				}
				//put round cards to winner
				//foreach (Card card in PlayerSettings.roundCards)
				for (int i = 0; i < PlayerSettings.roundCards.Length; i++)
				{
					if (!(PlayerSettings.roundCards[i] is null))
					{
						Game.Players[playerWinIdx].PlayerCards.Enqueue(PlayerSettings.roundCards[i]);
					}
				}
				//check victory
				for (int i = 0; i < PlayerSettings.AmountOfPlayers; i++)
				{
					if (Game.Players[i].PlayerCards.Count == 36)
					{
						WinStackPanel.Visibility = Visibility.Visible;
						TxtBlockPlayerWon.Text = $"{Game.Players[i].PlayerName} won! Congratulations!";
						NextTurnBtn.Foreground = Brushes.Black;
						LeaderPanel.Visibility = Visibility.Collapsed;
						NextTurnBtn.Visibility = Visibility.Collapsed;
						RestartBtn.Visibility = Visibility.Hidden;

						TitlePanel.SetValue(Grid.ColumnSpanProperty, 3);

						foreach (Label player in PlayerSettings.ControlPlayersNamesList)
						{
							player.Foreground = Brushes.Gray;
						}

						foreach (Image cardImage in PlayerSettings.ControlPlayersCardImagesList)
						{
							cardImage.Visibility = Visibility.Hidden;
						}

						PlayerSettings.ControlPlayersNamesList[i].Content = Game.Players[i].PlayerName + $"(36)";
						PlayerSettings.ControlPlayersNamesList[i].Foreground = (Brush)converter.ConvertFromString("#00FF00");
						//game over
						return;
					}
				}
				
				//start new round				
				//draw current leader
				this.LblLeader.Content = GetMaxCardsPlayer();
				//hide cards
				foreach (Image cardImage in PlayerSettings.ControlPlayersCardImagesList)
				{
					cardImage.Visibility = Visibility.Hidden;
				}
				//update player cards amount
				for (int i = 0; i < PlayerSettings.AmountOfPlayers; i++)
				{
					PlayerSettings.ControlPlayersNamesList[i].Content = $"{Game.Players[i].PlayerName} ({Game.Players[i].PlayerCards.Count})";
				}

				//reset round cards
				Array.Clear(PlayerSettings.roundCards, 0, PlayerSettings.AmountOfPlayers);
				PlayerSettings.CurrPlIdx = -1;
			}

			//-- Next turn --
			//define next active player
			PlayerSettings.CurrPlIdx = GetNextActivePlayerIdx(PlayerSettings.CurrPlIdx);

			//put card on table
			PlayerSettings.roundCards[PlayerSettings.CurrPlIdx] = (Game.Players[PlayerSettings.CurrPlIdx].PlayerCards.Dequeue());
			
			//add card image
			PlayerSettings.ControlPlayersCardImagesList[PlayerSettings.CurrPlIdx].Source =
				(ImageSource)imageSourceConverter.ConvertFrom($"../../Images/Cards/{PlayerSettings.roundCards[PlayerSettings.CurrPlIdx].CardSuit}_{PlayerSettings.roundCards[PlayerSettings.CurrPlIdx].CardType}.JPG");
			PlayerSettings.ControlPlayersCardImagesList[PlayerSettings.CurrPlIdx].Visibility = Visibility.Visible;
			//update player cards amount
			PlayerSettings.ControlPlayersNamesList[PlayerSettings.CurrPlIdx].Content =
			   $"{Game.Players[PlayerSettings.CurrPlIdx].PlayerName} ({Game.Players[PlayerSettings.CurrPlIdx].PlayerCards.Count})";

			//unmark all players
			for (int i = 0; i < Game.Players.Count; i++)
			{
				if (Game.Players[i].PlayerCards.Count == 0)
					PlayerSettings.ControlPlayersNamesList[i].Foreground = Brushes.Gray;
				else
					PlayerSettings.ControlPlayersNamesList[i].Foreground = Brushes.White;
			}

			//define and mark next player
			NextPlIdx = GetNextActivePlayerIdx(PlayerSettings.CurrPlIdx);

			//check no active players at current round
			if (NextPlIdx != PlayerSettings.AmountOfPlayers)
			{
				PlayerSettings.ControlPlayersNamesList[NextPlIdx].Foreground = (Brush)converter.ConvertFromString("#f76c6c");
			}
			else
			{
				int NextFirstPlayer = GetNextActivePlayerIdx(-1);
				PlayerSettings.ControlPlayersNamesList[NextFirstPlayer].Foreground = (Brush)converter.ConvertFromString("#f76c6c");
			}
		}
		private static int GetNextActivePlayerIdx(int startIdx)
		{
			while (++startIdx < PlayerSettings.AmountOfPlayers &&
				Game.Players[startIdx].PlayerCards.Count == 0)
			{
			}
			return startIdx;
		}

		private static string GetMaxCardsPlayer()
        {
	        int maxCardsValue = Game.Players.Max(player => player.PlayerCards.Count);
	        Player maxCardsPlayer = null;

	        foreach (var player in Game.Players)
	        {
		        if (player.PlayerCards.Count == maxCardsValue)
			        maxCardsPlayer = player;
	        }

	        return maxCardsPlayer.PlayerName;
        }

        private void BtnRestart_OnClick(object sender, RoutedEventArgs e)
        {
	        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
	        Application.Current.Shutdown();
        }
    }
}