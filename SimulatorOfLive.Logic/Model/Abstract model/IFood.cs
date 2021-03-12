using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorOfLive.Logic.Model.Abstract_model
{
    public interface IFood
    {
        byte Width { get; }
        byte Height { get; }
        int X { get; set; }
        int Y { get; set; }
    }
}
