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
                // imgDynamic.Source = new BitmapImage(fileUri);
            }
        }

        private void Player2PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                // imgDynamic.Source = new BitmapImage(fileUri);
            }
        }

        private void Player3PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                // imgDynamic.Source = new BitmapImage(fileUri);
            }
        }

        private void Player4PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                // imgDynamic.Source = new BitmapImage(fileUri);
            }
        }

        private void Player5PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                // imgDynamic.Source = new BitmapImage(fileUri);
            }
        }

        private void Player6PicButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                // imgDynamic.Source = new BitmapImage(fileUri);
            }
        }
    }
}