using System.IO;
using System.Xml.Serialization;
using System;
using SimulationOfLife.Logic.Abstract_model;
using SimulationOfLife.Logic.Model.Food;
using System.Collections.Generic;
using SimulatorOfLive.Logic.Model;

namespace SimulatorOfLive.Logic.Services
{
    public class SerializationService
    {
        public string Serialization(List<CellModel> cells, List<FoodModel> food)
        {
            string Name = DateTime.Now.ToString("yyyyMMdd_hhmmss");
            try
            {
                SavedGameModel savedGame = new SavedGameModel
                {
                    cells = cells,
                    food = food
                };
                var objects = new XmlSerializer(typeof(SavedGameModel));
                using (var file = new FileStream($"SavedGame ({Name}).xml", FileMode.Create))
                {
                    objects.Serialize(file, savedGame);
                }
                return $"SavedGame ({Name}).xml";
            }
            catch
            {
                return null;
            }
        }
        public SavedGameModel DeSerialization(string Path)
        {
            try
            {
                var objects = new XmlSerializer(typeof(SavedGameModel));
                using (var file = new FileStream(Path, FileMode.Open))
                {
                    return objects.Deserialize(file) as SavedGameModel;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
