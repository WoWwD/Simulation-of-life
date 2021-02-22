using SimulatorOfLive.Logic.Abstract_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorOfLive.Logic.Model
{
    public class MediumCell: FormOfCell
    {
        public override int Speed { get; set; }
        public override int Overview { get; set; }
        public override int Width { get; set; }
        public override int Height { get; set; }
        public override int X { get; set; }
        public override int Y { get; set; }
        public MediumCell(int X, int Y) : base(X, Y)
        {
            Speed = 7; // переделать
            Overview = 30; // переделать
            Width = 9;
            Height = 9;
        }
    }
}
