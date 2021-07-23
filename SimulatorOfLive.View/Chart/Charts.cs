using SimulationOfLife.Logic.Model;
using System.Collections.Generic;

namespace SimulatorOfLive.View.Chart
{
    public class Charts
    {
        public int a = 0, cycles = SettingsGame.AmountOfCycles;
        public int GetDataFromArray(int index, List<int> mas)
        {
            if (index != 0)
            {
                index /= 50;
            }
            if (index < mas.Count)
            {
                return mas[index];
            }
            return 0;
        }
    }
}
