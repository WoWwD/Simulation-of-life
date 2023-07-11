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
            int DirectionOfMove;
            foreach (var cell in objectController.cells)
            {
                if (cell is CarnivorousLowCell || cell is CarnivorousMediumCell || cell is CarnivorousHighCell)
                {
                    DirectionOfMove = TargetSearch(cell, objectController.cells);
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
                    DirectionOfMove = TargetSearch(cell, objectController.cells);
                    if (DirectionOfMove != 0)
                    {
                        cell.Move(MaxWidthField, MaxHeightField, cell.GetDirectionForGetaway(DirectionOfMove));
                        continue;
                    }
                    else
                    {
                        DirectionOfMove = TargetSearch(cell, objectController.food);
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
                        DirectionOfMove = TargetSearch(cell, objectController.cells);
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
                        DirectionOfMove = TargetSearch(cell, objectController.food);
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
        private int TargetSearch<C, T>(C creature, List<T> targets) where C : ICreature where T : IObject
        {
            int result;
            foreach (var target in targets)
            {
                result = creature.IsTargetInOverview(target.X, target.Y);
                if (result != 0 && creature.ID != target.ID)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        private object SearchForFood<C, T>(C creature, List<T> targets) where C : ICreature where T : IObject
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
                    result = SearchForFood(cell, objectController.cells);
                    if (result != null)
                    {
                        objectController.cells.RemoveAt((int)result);
                    }
                }
                if (cell is HerbivoreLowCell || cell is HerbivoreMediumCell || cell is HerbivoreHighCell)
                {
                    if (rnd.Next(SettingsGame.ChanceOfDefense) == 1)
                    {
                        result = SearchForFood(cell, objectController.cells);
                        if (result != null)
                        {
                            objectController.cells.RemoveAt((int)result);
                        }
                    }
                    else
                    {
                        result = SearchForFood(cell, objectController.food);
                        if (result != null)
                        {
                            objectController.food.RemoveAt((int)result);
                        }
                    }
                }
                if (cell is OmnivoreLowCell || cell is OmnivoreMediumCell || cell is OmnivoreHighCell)
                {
                    result = SearchForFood(cell, objectController.food);
                    if (result != null)
                    {
                        objectController.food.RemoveAt((int)result);
                    }
                    else
                    {
                        result = SearchForFood(cell, objectController.cells);
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