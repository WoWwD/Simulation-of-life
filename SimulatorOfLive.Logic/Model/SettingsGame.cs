using System;

namespace SimulatorOfLive.Logic.Model
{
    public static class SettingsGame
    {
        public static Guid guid = Guid.NewGuid();
        public static int CountOfCells = 500;
        public static int ChanceOfEvolutionCarnivorousLowCell = 10;
        public static int ChanceOfEvolutionCarnivorousMediumCell = 10;
        // public static int ChanceOfEvolutionCarnivorousHighCell = 10;
        public static int ChanceOfEvolutionHerbivoreLowCell = 10;
        public static int ChanceOfEvolutionHerbivoreMediumCell = 10;
        // public static int ChanceOfEvolutionHerbivoreHighCell = 10;
        public static int ChanceOfEvolutionOmnivoreLowCell = 10;
        public static int ChanceOfEvolutionOmnivoreMediumCell = 10;
        // public static int ChanceOfEvolutionOmnivoreHighCell = 10;
        public static int ChanceOfPursuit = 100;
        public static int ChanceOfDivision = 500;
        public static Random rnd = new Random();
        public static int SpeedOfGame = 9;
        public static double CountOfCarnivoriusCell = 0.7;
        public static double CountOfHerbivoreCells = 0.2;
        public static double CountOfOmnivoreCell = 0.1;
        public static object GetID()
        {
            return guid = Guid.NewGuid();
        }
    }
}