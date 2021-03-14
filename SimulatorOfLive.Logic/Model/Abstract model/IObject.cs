namespace SimulationOfLife.Logic.Model.Abstract_model
{
    /* Интерфейс описывает какой-либо объект в симуляции */
    public interface IObject
    {
        byte HitPoint { get; set; } // количество жизней
        byte Width { get; }  // ширина (px)
        byte Height { get; } // высота (px)
        int X { get; set; } // расположение на оси X
        int Y { get; set; } // расположение на оси Y
        void Damage(); // нанесение повреждений
    }
}