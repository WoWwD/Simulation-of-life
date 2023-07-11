using SimulationOfLife.Logic.Abstract_model;
using System;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Services
{
    public class StatisticsService
    {
        public Dictionary<string, int> dictionaryOfAncestors;
        public int sumDeaths, sumCycles, sumEvolutions, sumDivisions;
        public StatisticsService()
        {
            dictionaryOfAncestors = new Dictionary<string, int>();
            sumDeaths = 0;
            sumCycles = 0;
            sumEvolutions = 0;
            sumDivisions = 0;
        }
        public string LivingAncestors(List<CellModel> cells)
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
        public string AmountCells(double amount, int totalAmount, string typeCell) => 
            $"{typeCell}: {amount} ({Math.Round(amount / totalAmount, 3) * 100}%) клеток";
    }
}