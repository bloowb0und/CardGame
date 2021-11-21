using System;
using System.Collections.Generic;

namespace CardGame
{
    public static class PlayerSettings
    {
        public static int AmountOfPlayers { get; set; }

        public static List<string> PlayerNames { get; set; }
        public static List<Uri> PlayerPictureURLs { get; set; }

        static PlayerSettings()
        {
            PlayerNames = new List<string>();
            PlayerPictureURLs = new List<Uri>();
        }
    }
}