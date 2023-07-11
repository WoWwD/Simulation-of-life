using SimulationOfLife.Logic.Abstract_model;
using SimulationOfLife.Logic.Model;
using SimulationOfLife.Logic.Model.Abstract_model;
using SimulationOfLife.Logic.Model.Cell;
using SimulationOfLife.Logic.Model.Food;
using SimulatorOfLive.Logic.Controller;
using SimulatorOfLive.Logic.Services;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimulationOfLife.Logic.Controller
{
    [XmlInclude(typeof(FoodModel))]
    public class MainController
    {
        public SerializationService serializationService;
        public StatisticsService statisticsService;
        public ObjectController objectController;
        private Random rnd;

        public MainController()
        {
            objectController = new ObjectController();
            serializationService = new SerializationService();
            statisticsService = new StatisticsService();
            rnd = new Random();
        }

        #region Поведение клеток
        public void Move(int MaxWidthField, int MaxHeightField)
        {
            int DirectionOfMove = 0;
            foreach (var cell in objectController.cells)
            {
                if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                {
                    SearchOfTarget(ref DirectionOfMove, cell, objectController.cells);
                    if (DirectionOfMove != 0)
                    {
                        cell.Move(MaxWidthField, MaxHeightField, DirectionOfMove);
                        continue;
                    }
                    else
                    {
                        cell.Move(MaxWidthField, MaxHeightField, rnd.Next(SettingsGame.SpeedOfGame));
                        continue;
                    }
                }
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    SearchOfTarget(ref DirectionOfMove, cell, objectController.cells);
                    if (DirectionOfMove != 0)
                    {
                        if (DirectionOfMove == 1)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 3);
                            continue;
                        }
                        if (DirectionOfMove == 2)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 4);
                            continue;
                        }
                        if (DirectionOfMove == 3)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 1);
                            continue;
                        }
                        if (DirectionOfMove == 4)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 2);
                            continue;
                        }
                        if (DirectionOfMove == 5)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 7);
                            continue;
                        }
                        if (DirectionOfMove == 6)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 8);
                            continue;
                        }
                        if (DirectionOfMove == 7)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 5);
                            continue;
                        }
                        if (DirectionOfMove == 8)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, 6);
                            continue;
                        }
                    }
                    else
                    {
                        SearchOfTarget(ref DirectionOfMove, cell, objectController.food);
                        if (DirectionOfMove != 0)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, DirectionOfMove);
                            continue;
                        }
                        else
                        {
                            cell.Move(MaxWidthField, MaxHeightField, rnd.Next(SettingsGame.SpeedOfGame));
                            continue;
                        }
                    }
                }
                if (cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    int r = rnd.Next(2);
                    if (r == 0)
                    {
                        SearchOfTarget(ref DirectionOfMove, cell, objectController.cells);
                        if (DirectionOfMove != 0)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, DirectionOfMove);
                            continue;
                        }
                        else
                        {
                            cell.Move(MaxWidthField, MaxHeightField, rnd.Next(SettingsGame.SpeedOfGame));
                            continue;
                        }
                    }
                    if (r == 1)
                    {
                        SearchOfTarget(ref DirectionOfMove, cell, objectController.food);
                        if (DirectionOfMove != 0)
                        {
                            cell.Move(MaxWidthField, MaxHeightField, DirectionOfMove);
                            continue;
                        }
                        else
                        {
                            cell.Move(MaxWidthField, MaxHeightField, rnd.Next(SettingsGame.SpeedOfGame));
                            continue;
                        }
                    }
                }
            }
        }
        private bool SearchOfTarget<C, T>(ref int DirectionOfMove, C creature, List<T> targets) where C : ICreature where T : IObject
        {
            int result;
            foreach (var target in targets)
            {
                result = creature.IsTargetInOverview(target.X, target.Y);
                if (result != 0 && creature.ID != target.ID)
                {
                    DirectionOfMove = result;
                    return true;
                }
                else
                {
                    DirectionOfMove = 0;
                    return false;
                }
            }
            DirectionOfMove = 0;
            return false;
        }
        private object SearchTargetForEating<C, T>(C creature, List<T> targets) where C : ICreature where T : IObject
        {
            bool result;
            foreach (var target in targets)
            {
                result = creature.IsTargetInRegionOfEating(target.X, target.Y);
                if (result == true && creature.ID != target.ID)
                {
                    result = creature.Eating(target.HitPoint);
                    if (result == true)
                    {
                        statisticsService.sumDeaths++;
                        int index = targets.LastIndexOf(target);
                        return index;
                    }
                    else
                    {
                        target.Damage();
                        return null;
                    }
                }
            }
            return null;
        }
        public void Eating()
        {
            object result;
            foreach (var cell in objectController.cells.ToArray())
            {
                if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                {
                    result = SearchTargetForEating(cell, objectController.cells);
                    if (result != null)
                    {
                        objectController.cells.RemoveAt((int)result);
                    }
                }
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    if (rnd.Next(SettingsGame.ChanceOfDefense) == 1)
                    {
                        result = SearchTargetForEating(cell, objectController.cells);
                        if (result != null)
                        {
                            objectController.cells.RemoveAt((int)result);
                        }
                    }
                    else
                    {
                        result = SearchTargetForEating(cell, objectController.food);
                        if (result != null)
                        {
                            objectController.food.RemoveAt((int)result);
                        }
                    }
                }
                if (cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    result = SearchTargetForEating(cell, objectController.food);
                    if (result != null)
                    {
                        objectController.food.RemoveAt((int)result);
                    }
                    else
                    {
                        result = SearchTargetForEating(cell, objectController.cells);
                        if (result != null)
                        {
                            objectController.cells.RemoveAt((int)result);
                        }
                    }
                }
            }
        }
        public void Evolution()
        {
            foreach (var cell in objectController.cells.ToArray())
            {
                if (cell is CarnivorousLowCell && cell.IsEvolution(rnd.Next(SettingsGame.ChanceOfEvolutionCarnivorousLowCell)))
                {
                    statisticsService.sumEvolutions++;
                    objectController.cells.Add(new CarnivorousMediumCell(cell.X, cell.Y, cell.ID));
                    objectController.cells.RemoveAll(c => c == cell);
                }
                if (cell is CarnivorousMediumCell && cell.IsEvolution(rnd.Next(SettingsGame.ChanceOfEvolutionCarnivorousMediumCell)))
                {
                    statisticsService.sumEvolutions++;
                    objectController.cells.Add(new CarnivorousHighCell(cell.X, cell.Y, cell.ID));
                    objectController.cells.RemoveAll(c => c == cell);
                }
                if (cell is HerbivoreLowCell && cell.IsEvolution(rnd.Next(SettingsGame.ChanceOfEvolutionHerbivoreLowCell)))
                {
                    statisticsService.sumEvolutions++;
                    objectController.cells.Add(new HerbivoreMediumCell(cell.X, cell.Y, cell.ID));
                    objectController.cells.RemoveAll(c => c == cell);
                }
                if (cell is HerbivoreMediumCell && cell.IsEvolution(rnd.Next(SettingsGame.ChanceOfEvolutionHerbivoreMediumCell)))
                {
                    statisticsService.sumEvolutions++;
                    objectController.cells.Add(new HerbivoreHighCell(cell.X, cell.Y, cell.ID));
                    objectController.cells.RemoveAll(c => c == cell);
                }
                if (cell is OmnivoreLowCell && cell.IsEvolution(rnd.Next(SettingsGame.ChanceOfEvolutionOmnivoreLowCell)))
                {
                    statisticsService.sumEvolutions++;
                    objectController.cells.Add(new OmnivoreMediumCell(cell.X, cell.Y, cell.ID));
                    objectController.cells.RemoveAll(c => c == cell);
                }
                if (cell is OmnivoreMediumCell && cell.IsEvolution(rnd.Next(SettingsGame.ChanceOfEvolutionOmnivoreMediumCell)))
                {
                    statisticsService.sumEvolutions++;
                    objectController.cells.Add(new OmnivoreHighCell(cell.X, cell.Y, cell.ID));
                    objectController.cells.RemoveAll(c => c == cell);
                }
            }
        }
        private void AddCell<T>(T cell) where T : CellModel => objectController.cells.Add(cell);
        public bool Division()
        {
            foreach (var cell in objectController.cells.ToArray())
            {
                if (cell.IsDivision(rnd.Next(SettingsGame.ChanceOfDivision)))
                {
                    statisticsService.sumDivisions++;
                    AddCell(cell);
                    return true;
                }
                break;
            }
            return false;
        }
        #endregion
        public void Cycle(int MaxWidthField, int MaxHeightField)
        {
            objectController.AddFood(MaxWidthField, MaxHeightField);
            Move(MaxWidthField, MaxHeightField);
            Eating();
            if (objectController.cells != null && objectController.cells.Count != 0) Division();
            Evolution();
            statisticsService.sumCycles++;
        }
    }
}