using System;

namespace SimulatorOfLive.Logic.Model
{
    public static class SettingsGame
    {
        public static readonly Random rnd = new Random();
        public static Guid guid = Guid.NewGuid();
        public static int CountOfCells = 500; // Количество начальных клеток

        #region Эволюция клеток
        public static int ChanceOfEvolutionCarnivorousLowCell = 10; // Шанс плотоядной клетки низкого уровня эволюционировать
        public static int ChanceOfEvolutionCarnivorousMediumCell = 10; // Шанс плотоядной клетки среднего уровня эволюционировать
        // public static int ChanceOfEvolutionCarnivorousHighCell = 10; // Шанс плотоядной клетки высшего уровня эволюционировать
        public static int ChanceOfEvolutionHerbivoreLowCell = 10; // Шанс травоядной клетки низкого уровня эволюционировать
        public static int ChanceOfEvolutionHerbivoreMediumCell = 10; // Шанс травоядной клетки среднего уровня эволюционировать
        // public static int ChanceOfEvolutionHerbivoreHighCell = 10; // Шанс травоядной клетки высшего уровня эволюционировать
        public static int ChanceOfEvolutionOmnivoreLowCell = 10; // Шанс всеядной клетки низкого уровня эволюционировать
        public static int ChanceOfEvolutionOmnivoreMediumCell = 10; // Шанс всеядной клетки низкого уровня эволюционировать
        // public static int ChanceOfEvolutionOmnivoreHighCell = 10; // Шанс всеядной клетки высшего уровня эволюционировать
        #endregion

        public static int ChanceOfPursuit = 50; // Шанс преследования цели клеткой
        public static int ChanceOfRun = 50; // Шанс побега клетки от вражеской
        public static int ChanceOfDivision = 50; // Шанс деления клетки

        public static int SpeedOfGame = 9; // Скорость игры. Чем больше, тем медленнее.

        public static double CountOfCarnivoriusCell = 0.4; // Доля (% от общего количества клеток) плотоядных клеток в начале
        public static double CountOfHerbivoreCells = 0.4; // Доля (% от общего количества клеток) травоядных клеток в начале
        public static double CountOfOmnivoreCell = 0.2; // Доля (% от общего количества клеток) всеядных клеток в начале
        public static object GetID() 
        {
            return guid = Guid.NewGuid();
        }
        public static int RndNumber(int param)
        {
            return rnd.Next(param);
        }
    }
}