using SimulationOfLife.Logic.Model;
using SimulationOfLife.Logic.Model.Abstract_model;
using SimulationOfLife.Logic.Model.Cell;
using System.Xml.Serialization;

namespace SimulationOfLife.Logic.Abstract_model
{
    [XmlInclude(typeof(CarnivorousLowCell))]
    [XmlInclude(typeof(CarnivorousMediumCell))]
    [XmlInclude(typeof(CarnivorousHighCell))]
    [XmlInclude(typeof(HerbivoreLowCell))]
    [XmlInclude(typeof(HerbivoreMediumCell))]
    [XmlInclude(typeof(HerbivoreHighCell))]
    [XmlInclude(typeof(OmnivoreLowCell))]
    [XmlInclude(typeof(OmnivoreMediumCell))]
    [XmlInclude(typeof(OmnivoreHighCell))]
    public abstract class FormOfCell : ICreature, IObject
    {
        public string ID { get; set; }
        public abstract byte Speed { get; }
        public abstract byte Overview { get; }
        public abstract byte Width { get; }
        public abstract byte Height { get; }
        public abstract byte HitPoint { get; set; }
        public abstract byte RegionOfEating { get; }
        public abstract int CountOfEating { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Eating(int HitPointTarget)
        {
            if (HitPointTarget == 0)
            {
                CountOfEating++;
                return true;
            }
            return false;
        }
        public void Move(int MaxWidthField, int MaxHeightField, int DirectionOfMove)
        {
            /* Движение вправо */
            if (DirectionOfMove == 1)
            {
                X += Speed;
                if (X >= MaxWidthField)
                {
                    X -= Speed;
                }
            }
            /* Движение влево */
            if (DirectionOfMove == 2)
            {
                X -= Speed;
                if (X <= 0)
                {
                    X += Speed;
                }
            }
            /* Движение вниз */
            if (DirectionOfMove == 3)
            {
                Y += Speed;
                if (Y >= MaxHeightField)
                {
                    Y -= Speed;
                }
            }
            /* Движение вверх */
            if (DirectionOfMove == 4)
            {
                Y -= Speed;
                if (Y <= 0)
                {
                    Y += Speed;
                }
            }
            /* Движение по первой четверти */
            if (DirectionOfMove == 5)
            {
                X += Speed;
                Y -= Speed;
                if (X >= MaxWidthField)
                {
                    X -= Speed;
                }
                if (Y <= 0)
                {
                    Y += Speed;
                }
            }
            /* Движение по второй четверти */
            if (DirectionOfMove == 6)
            {
                X -= Speed;
                Y -= Speed;
                if (X <= 0)
                {
                    X += Speed;
                }
                if (Y >= MaxHeightField)
                {
                    Y += Speed;
                }
            }
            /* Движение по третьей четверти */
            if (DirectionOfMove == 7)
            {
                X -= Speed;
                Y += Speed;
                if (X <= 0)
                {
                    X += Speed;
                }
                if (Y <= 0)
                {
                    Y -= Speed;
                }
            }
            /* Движение по четвертой четверти */
            if (DirectionOfMove == 8)
            {
                X += Speed;
                Y += Speed;
                if (X >= MaxWidthField)
                {
                    X -= Speed;
                }
                if (Y >= MaxHeightField)
                {
                    Y -= Speed;
                }
            }
        }
        public abstract bool IsEvolution();
        public void Damage()
        {
            HitPoint--;
        }
        public bool IsDivision()
        {
            if (SettingsGame.RndNumber(SettingsGame.ChanceOfDivision) == 1 && CountOfEating >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int IsTargetInOverview(int XTarget, int YTarget)
        {
            int viewRight, viewLeft, viewUp, viewDown;
            viewRight = X + Overview;
            viewLeft = X - Overview;
            viewUp = Y - Overview;
            viewDown = Y + Overview;
            /* цель справа на одной высоте*/
            if (XTarget >= X && XTarget <= viewRight && YTarget == Y)
            {
                return 1;
            }
            /* цель слева на одной высоте*/
            if (XTarget <= X && XTarget >= viewLeft && YTarget == Y)
            {
                return 2;
            }
            /* цель снизу на одной ширине */
            if (YTarget >= Y && YTarget <= viewDown && XTarget == X)
            {
                return 3;
            }
            /* цель сверху на одной ширине */
            if (YTarget <= Y && YTarget >= viewUp && XTarget == X)
            {
                return 4;
            }
            /* цель в первой четверти */
            if ((XTarget >= X && XTarget <= viewRight) && (YTarget <= Y && YTarget >= viewUp))
            {
                return 5;
            }
            /* цель во второй четверти */
            if ((XTarget <= X && XTarget >= viewLeft) && (YTarget <= Y && YTarget >= viewUp))
            {
                return 6;
            }
            /* цель в третьей четверти */
            if ((XTarget <= X && XTarget >= viewLeft) && (YTarget >= Y && YTarget <= viewDown))
            {
                return 7;
            }
            /* цель в четвертой четверти */
            if ((XTarget >= X && XTarget <= viewRight) && (YTarget >= Y && YTarget <= viewDown))
            {
                return 8;
            }
            return 0;
        }
        public bool IsTargetInRegionOfEating(int XTarget, int YTarget)
        {
            int RegionOfEatingLeft, RegionOfEatingRight, RegionOfEatingUp, RegionOfEatingDown;
            RegionOfEatingRight = X + RegionOfEating;
            RegionOfEatingLeft = X - RegionOfEating;
            RegionOfEatingUp = Y - RegionOfEating;
            RegionOfEatingDown = Y + RegionOfEating;
            /* цель справа на одной высоте*/
            if (XTarget >= X && XTarget <= RegionOfEatingRight && YTarget == Y)
            {
                return true;
            }
            /* цель слева на одной высоте*/
            if (XTarget <= X && XTarget >= RegionOfEatingLeft && YTarget == Y)
            {
                return true;
            }
            /* цель снизу на одной ширине */
            if (YTarget >= Y && YTarget <= RegionOfEatingDown && XTarget == X)
            {
                return true;
            }
            /* цель сверху на одной ширине */
            if (YTarget <= Y && YTarget >= RegionOfEatingUp && XTarget == X)
            {
                return true;
            }
            /* цель в первой четверти */
            if ((XTarget >= X && XTarget <= RegionOfEatingRight) && (YTarget <= Y && YTarget >= RegionOfEatingUp))
            {
                return true;
            }
            /* цель во второй четверти */
            if ((XTarget <= X && XTarget >= RegionOfEatingLeft) && (YTarget <= Y && YTarget >= RegionOfEatingUp))
            {
                return true;
            }
            /* цель в третьей четверти */
            if ((XTarget <= X && XTarget >= RegionOfEatingLeft) && (YTarget >= Y && YTarget <= RegionOfEatingDown))
            {
                return true;
            }
            /* цель в четвертой четверти */
            if ((XTarget >= X && XTarget <= RegionOfEatingRight) && (YTarget >= Y && YTarget <= RegionOfEatingDown))
            {
                return true;
            }
            return false;
        }
        public FormOfCell() { }
        public FormOfCell(int X, int Y, string ID)
        {
            this.X = X;
            this.Y = Y;
            this.ID = ID;
        }
    }
}