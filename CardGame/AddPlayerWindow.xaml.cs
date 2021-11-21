using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace CardGame
{
    public partial class AddPlayerWindow : Window
    {
        public AddPlayerWindow()
        {
            InitializeComponent();
        }

        private void Player1PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                PlayerSettings.PlayerPictureURLs.Add(fileUri);
                // PlayerSettings.Player1PictureURL = fileUri;
            }
        }

        private void Player2PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                PlayerSettings.PlayerPictureURLs.Add(fileUri);
            }
        }

        private void Player3PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                PlayerSettings.PlayerPictureURLs.Add(fileUri);
            }
        }

        private void Player4PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                PlayerSettings.PlayerPictureURLs.Add(fileUri);
            }
        }

        private void Player5PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                PlayerSettings.PlayerPictureURLs.Add(fileUri);
            }
        }

        private void Player6PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                PlayerSettings.PlayerPictureURLs.Add(fileUri);
            }
        }

        private void OnStartGameButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerSettings.AmountOfPlayers = (int) this.myUpDownControl.Value;

            for (int i = 0; i < PlayerSettings.AmountOfPlayers; i++)
            {
                if(i == 0)
                    PlayerSettings.PlayerNames.Add(this.Player1Name.Text);
                else if(i == 1)
                    PlayerSettings.PlayerNames.Add(this.Player2Name.Text);
                else if(i == 2)
                    PlayerSettings.PlayerNames.Add(this.Player3Name.Text);
                else if(i == 3)
                    PlayerSettings.PlayerNames.Add(this.Player4Name.Text);
                else if(i == 4)
                    PlayerSettings.PlayerNames.Add(this.Player5Name.Text);
                else if(i == 5)
                    PlayerSettings.PlayerNames.Add(this.Player6Name.Text);
            }

            MainWindow gameWindow = new MainWindow();
            gameWindow.ShowDialog();
            // this.WindowState = WindowState.Minimized;
        }

        private void SpinBox_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (this.myUpDownControl.Value == 2)
            {
                if(FourPlayersStack != null)
                    FourPlayersStack.Visibility = Visibility.Collapsed;
                if(SixPlayersStack != null)
                    SixPlayersStack.Visibility = Visibility.Collapsed;
            }
            else if (this.myUpDownControl.Value == 4)
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