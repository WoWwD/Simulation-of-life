using SimulationOfLife.Logic.Abstract_model;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Services
{
    public class Statistics
    {
        public Dictionary<string, int> dictionaryOfAncestors;
        public Statistics()
        {
            dictionaryOfAncestors = new Dictionary<string, int>();
        }
        public string CountingCells(List<FormOfCell> cells)
        {
            int count = 0;
            string name = "no value";
            dictionaryOfAncestors.Clear();
            foreach (var cell in cells)
            {
                if (dictionaryOfAncestors.ContainsKey(cell.ID))
                {
                    dictionaryOfAncestors[cell.ID]++;
                }
                else
                {
                    dictionaryOfAncestors.Add(cell.ID, 1);
                }
            }
            foreach (var cell in dictionaryOfAncestors)
            {
                if (cell.Value > count)
                {
                    count = cell.Value;
                    name = cell.Key;
                }
            }
            return $"Наибольшее количество живых потомков у \"{name}\": {count}";
        }

    }
}