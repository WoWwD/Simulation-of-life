namespace SimulationOfLife.Logic.Model
{
    public static class SettingsGame
    {
        public const int AmountOfCells = 750;
        public const int AmountOfCycles = 2000;
        public const int CountOfEatForDivision = 2;
        public const int UpdateRate = 50; 

        public const int ChanceOfDefense = 10; // Шанс травоядной клетки нанести урон вражеской клетке
        public const int ChanceOfDivision = 5; // Шанс деления клетки
        public const int SpeedOfGame = 10; // Скорость игры. Чем больше, тем медленнее.
        public const double CountOfCarnivoriusCell = 0.4; // Доля (% от общего количества клеток) плотоядных клеток в начале
        public const double CountOfHerbivoreCells = 0.4; // Доля (% от общего количества клеток) травоядных клеток в начале
        public const double CountOfOmnivoreCell = 0.2; // Доля (% от общего количества клеток) всеядных клеток в начале

        #region Эволюция клеток

        #region Шанс эволюции

        public const int ChanceOfEvolutionCarnivorousLowCell = 10; 
        public const int ChanceOfEvolutionCarnivorousMediumCell = 10; 

        public const int ChanceOfEvolutionHerbivoreLowCell = 10; 
        public const int ChanceOfEvolutionHerbivoreMediumCell = 10; 

        public const int ChanceOfEvolutionOmnivoreLowCell = 10; 
        public const int ChanceOfEvolutionOmnivoreMediumCell = 10;                                                    

        #endregion

        #region Количество еды, необходимое для эволюции

        public const int CountOfEatForEvolutionCarnivorousLowCell = 4;
        public const int CountOfEatForEvolutionCarnivorousMediumCell = 5;

        public const int CountOfEatForEvolutionHerbivoreLowCell = 3;
        public const int CountOfEatForEvolutionHerbivoreMediumCell = 4;

        public const int CountOfEatForEvolutionOmnivoreLowCell = 4;
        public const int CountOfEatForEvolutionOmnivoreMediumCell = 5;

        #endregion

        #endregion

        #region Еда

        public const int FoodLimit = 150; // Предел еды, после которого она удаляется с поля
        public const byte ChanceOfAddingFood = 20; // Вероятность добавления еды на поле
        public const byte ChanceOfDeletingFood = 30; // Вероятность удаления еды с поля в течение игры

        #endregion
    }
}