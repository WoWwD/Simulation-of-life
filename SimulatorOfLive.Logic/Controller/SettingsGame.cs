using System;

namespace SimulatorOfLive.Logic.Model
{
    public static class SettingsGame
    {
        public static readonly Random rnd = new Random();
        public static Guid guid = Guid.NewGuid();
        public static int CountOfCells = 500; // Количество начальных клеток

        #region Эволюция клеток
        #region Шанс эволюции
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
        #region Количество еды для эволюции
        public static int CountOfEatForEvolutionCarnivorousLowCell = 3;
        public static int CountOfEatForEvolutionCarnivorousMediumCell = 4;
        // public static int CountOfEatForEvolutionCarnivorousHighCell = 3;
        public static int CountOfEatForEvolutionHerbivoreLowCell = 3;
        public static int CountOfEatForEvolutionHerbivoreMediumCell = 3;
        // public static int CountOfEatForEvolutionHerbivoreHighCell = 3;
        public static int CountOfEatForEvolutionOmnivoreLowCell = 4;
        public static int CountOfEatForEvolutionOmnivoreMediumCell = 5;
        // public static int CountOfEatForEvolutionOmnivoreHighCell = 3;
        #endregion
        #endregion

        public static int ChanceOfPursuit = 25; // Шанс преследования цели клеткой
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