using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Windows.Controls;

namespace CardGame
{
    public static class PlayerSettings
    {
        public static int AmountOfPlayers { get; set; }

        public static List<string> PlayerNames { get; set; }
        public static List<Uri> PlayerPictureURLs { get; set; }
        
        public static List<Image> ControlPlayersImagesList { get; set; }
        public static List<Label> ControlPlayersNamesList { get; set; }
        public static List<Image> ControlPlayersCardImagesList { get; set; }

		public static int CurrPlIdx { get; set; }
		public static Card[] roundCards { get; set; }


		static PlayerSettings()
        {
            PlayerNames = new List<string>();
            PlayerPictureURLs = new List<Uri>();

            for (int i = 0; i < 6; i++)
            {
                PlayerPictureURLs.Add(new Uri("Images/playerDefault.png", UriKind.Relative));
            }

            ControlPlayersImagesList = new List<Image>();
            ControlPlayersNamesList = new List<Label>();
            ControlPlayersCardImagesList = new List<Image>();
			CurrPlIdx = -1;
			roundCards = new Card[AmountOfPlayers];
        }
    }
}