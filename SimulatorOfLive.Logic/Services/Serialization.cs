using System.IO;
using System.Xml.Serialization;
using System;
using SimulationOfLife.Logic.Abstract_model;
using SimulationOfLife.Logic.Model.Food;
using System.Collections.Generic;

namespace SimulatorOfLive.Logic.Services
{
    public class SerializationService
    {
        public string Serialization(List<FormOfCell> cells, List<Food> food)
        {
            string Name = DateTime.Now.ToString("yyyyMMdd_hhmmss");
            try
            {
                SavedGame savedGame = new SavedGame
                {
                    cells = cells,
                    food = food
                };
                var objects = new XmlSerializer(typeof(SavedGame));
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
        public SavedGame DeSerialization(string Path)
        {
            try
            {
                var objects = new XmlSerializer(typeof(SavedGame));
                using (var file = new FileStream(Path, FileMode.Open))
                {
                    return objects.Deserialize(file) as SavedGame;
                }
            }
            catch
            {
                return null;
            }
        }
    }

    public class SavedGame
    {
        public List<FormOfCell> cells;
        public List<Food> food;
    }
}