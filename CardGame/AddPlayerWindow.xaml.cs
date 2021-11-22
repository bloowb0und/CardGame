using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace CardGame
{
    public partial class AddPlayerWindow : Window
    {
        public bool IsStarted;
        
        public AddPlayerWindow()
        {
            InitializeComponent();
            IsStarted = false;

            PlayerSettings.AmountOfPlayers = 2;
        }

        private void Player1PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                PlayerSettings.PlayerPictureURLs[0] = fileUri;
            }
        }

        private void Player2PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                PlayerSettings.PlayerPictureURLs[1] = fileUri;
            }
        }

        private void Player3PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                PlayerSettings.PlayerPictureURLs[2] = fileUri;
            }
        }

        private void Player4PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                PlayerSettings.PlayerPictureURLs[3] = fileUri;
            }
        }

        private void Player5PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                PlayerSettings.PlayerPictureURLs[4] = fileUri;
            }
        }

        private void Player6PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                PlayerSettings.PlayerPictureURLs[5] = fileUri;
            }
        }

        private void OnStartGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsStarted = true;
            PlayerSettings.AmountOfPlayers = (int) this.MyUpDownControl.Value;
            List<TextBox> controlPlayerNames = new List<TextBox>();
            
            controlPlayerNames.Add(this.Player1Name);
            controlPlayerNames.Add(this.Player2Name);
            controlPlayerNames.Add(this.Player3Name);
            controlPlayerNames.Add(this.Player4Name);
            controlPlayerNames.Add(this.Player5Name);
            controlPlayerNames.Add(this.Player6Name);

            for (int i = 0; i < PlayerSettings.AmountOfPlayers; i++)
            {
                if (controlPlayerNames[i].Text != String.Empty)
                    PlayerSettings.PlayerNames.Add(controlPlayerNames[i].Text);
                else
                    PlayerSettings.PlayerNames.Add("player" + (i + 1));
            }
            
            this.Close();
        }

        private void SpinBox_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (this.MyUpDownControl.Value == 2)
            {
                if(FourPlayersStack != null)
                    FourPlayersStack.Visibility = Visibility.Collapsed;
                if(SixPlayersStack != null)
                    SixPlayersStack.Visibility = Visibility.Collapsed;
            }
            else if (this.MyUpDownControl.Value == 4)
            {
                FourPlayersStack.Visibility = Visibility.Visible;
                SixPlayersStack.Visibility = Visibility.Collapsed;
            }
            else
            {
                FourPlayersStack.Visibility = Visibility.Visible;
                SixPlayersStack.Visibility = Visibility.Visible;
            }
        }
    }
}