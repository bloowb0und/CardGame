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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnGameWindow_Loaded(object sender, RoutedEventArgs e)
        {
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

            ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
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
    }
}