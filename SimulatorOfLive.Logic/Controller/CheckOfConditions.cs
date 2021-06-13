using SimulationOfLife.Logic.Model;

namespace SimulatorOfLive.Logic.Controller
{
    public static class CheckOfConditions
    {
        public static bool Check()
        {
            if (SettingsGame.CountOfHerbivoreCells + SettingsGame.CountOfOmnivoreCell + SettingsGame.CountOfCarnivoriusCell == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
