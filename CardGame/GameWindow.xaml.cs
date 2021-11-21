using System;
using System.ComponentModel;
using System.Windows;
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
            LblCurrentTurn.Content = PlayerSettings.PlayerNames[0];
            
            this.Player1Image.Stretch = Stretch.Fill;
            this.Player1Image.Width = 70;
            this.Player1Image.Height = 130;
            this.Player2Image.Stretch = Stretch.Fill;
            this.Player2Image.Width = 70;
            this.Player2Image.Height = 130;
            this.Player3Image.Stretch = Stretch.Fill;
            this.Player3Image.Width = 70;
            this.Player3Image.Height = 130;
            this.Player4Image.Stretch = Stretch.Fill;
            this.Player4Image.Width = 70;
            this.Player4Image.Height = 130;
            this.Player5Image.Stretch = Stretch.Fill;
            this.Player5Image.Width = 70;
            this.Player5Image.Height = 130;
            this.Player6Image.Stretch = Stretch.Fill;
            this.Player6Image.Width = 70;
            this.Player6Image.Height = 130;

            ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
            for (int i = 0; i < PlayerSettings.PlayerPictureURLs.Count; i++)
            {
                if (i == 0)
                {
                    if (PlayerSettings.PlayerPictureURLs[i] == null)
                        this.Player1Image.Source = (ImageSource) imageSourceConverter.ConvertFrom("Images/playerDefault.png");
                    else
                        this.Player1Image.Source = new BitmapImage(PlayerSettings.PlayerPictureURLs[i]);
                }
                else if (i == 1)
                {
                    if (PlayerSettings.PlayerPictureURLs[i] == null)
                        this.Player2Image.Source = (ImageSource) imageSourceConverter.ConvertFrom("Images/playerDefault.png");
                    else
                        this.Player2Image.Source = new BitmapImage(PlayerSettings.PlayerPictureURLs[i]);
                }
                else if (i == 2)
                {
                    if (PlayerSettings.PlayerPictureURLs[i] == null)
                        this.Player3Image.Source = (ImageSource) imageSourceConverter.ConvertFrom("Images/playerDefault.png");
                    else
                        this.Player3Image.Source = new BitmapImage(PlayerSettings.PlayerPictureURLs[i]);
                }
                else if (i == 3)
                {
                    if (PlayerSettings.PlayerPictureURLs[i] == null)
                        this.Player4Image.Source = (ImageSource) imageSourceConverter.ConvertFrom("Images/playerDefault.png");
                    else
                        this.Player4Image.Source = new BitmapImage(PlayerSettings.PlayerPictureURLs[i]);
                }
                else if (i == 4)
                {
                    if (PlayerSettings.PlayerPictureURLs[i] == null)
                        this.Player5Image.Source = (ImageSource) imageSourceConverter.ConvertFrom("Images/playerDefault.png");
                    else
                        this.Player5Image.Source = new BitmapImage(PlayerSettings.PlayerPictureURLs[i]);
                }
                else if (i == 5)
                {
                    if (PlayerSettings.PlayerPictureURLs[i] == null)
                        this.Player6Image.Source = (ImageSource) imageSourceConverter.ConvertFrom("Images/playerDefault.png");
                    else
                        this.Player6Image.Source = new BitmapImage(PlayerSettings.PlayerPictureURLs[i]);
                }
            }

            int amountOfCardsForEach = 36 / PlayerSettings.AmountOfPlayers;

            for (int i = 0; i < PlayerSettings.AmountOfPlayers; i++)
            {
                if(i == 0)
                    this.Player1Name.Content = PlayerSettings.PlayerNames[i] + $"({amountOfCardsForEach})";
                else if(i == 1)
                    this.Player2Name.Content = PlayerSettings.PlayerNames[i] + $"({amountOfCardsForEach})";
                else if(i == 2)
                    this.Player3Name.Content = PlayerSettings.PlayerNames[i] + $"({amountOfCardsForEach})";
                else if(i == 3)
                    this.Player4Name.Content = PlayerSettings.PlayerNames[i] + $"({amountOfCardsForEach})";
                else if(i == 4)
                    this.Player5Name.Content = PlayerSettings.PlayerNames[i] + $"({amountOfCardsForEach})";
                else if(i == 5)
                    this.Player6Name.Content = PlayerSettings.PlayerNames[i] + $"({amountOfCardsForEach})";
            }
            
        }
    }
}