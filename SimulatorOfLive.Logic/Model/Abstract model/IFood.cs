namespace SimulatorOfLive.Logic.Model.Abstract_model
{
    /* Интерфейс описывает объект, который может быть съеден существом */
    public interface IFood
    {
        byte Width { get; }  // ширина (px)
        byte Height { get; } // высота (px)
        int X { get; set; } // расположение на оси X
        int Y { get; set; } // расположение на оси Y
    }
}
