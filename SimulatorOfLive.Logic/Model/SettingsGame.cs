using System;

namespace SimulatorOfLive.Logic.Model
{
    public static class SettingsGame
    {
        public static int ChanceOfEvolutionCarnivorousLowCell = 10;
        public static int ChanceOfEvolutionCarnivorousMediumCell = 10;
        // public static int ChanceOfEvolutionCarnivorousHighCell = 10;
        public static int ChanceOfEvolutionHerbivoreLowCell = 10;
        public static int ChanceOfEvolutionHerbivoreMediumCell = 10;
        // public static int ChanceOfEvolutionHerbivoreHighCell = 10;
        public static int ChanceOfPursuit = 1000;
        public static Random rnd = new Random();
        public static int SpeedOfGame = 9;
    }
}