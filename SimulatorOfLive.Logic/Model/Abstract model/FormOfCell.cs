using SimulatorOfLive.Logic.Model;
using SimulatorOfLive.Logic.Model.Abstract_model;
using SimulatorOfLive.Logic.Model.Cell;
using SimulatorOfLive.Logic.Model.Eat;
using System.Xml.Serialization;

namespace SimulatorOfLive.Logic.Abstract_model
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
    public abstract class FormOfCell : ICreature, ILocation
    {
        public string ID { get; set; }
        public abstract byte Speed { get; }
        public abstract byte Overview { get; }
        public abstract byte Width { get; }
        public abstract byte Height { get; }
        public abstract byte HitPoint { get; set; }
        public abstract byte RegionOfEating { get; }
        public abstract int CountOfEating { get; set; }
        public abstract bool PathIsClear { get; set; } // свободен ли путь для клетки
        public int X { get; set; }
        public int Y { get; set; }
        public bool Eat<T>(int MaxWidthField, int MaxHeightField, T target) where T : FormOfCell
        {
            int RegionOfEatingLeft, RegionOfEatingRight, RegionOfEatingUp, RegionOfEatingDown;
            RegionOfEatingRight = X + RegionOfEating;
            RegionOfEatingLeft = X - RegionOfEating;
            RegionOfEatingUp = Y - RegionOfEating;
            RegionOfEatingDown = Y + RegionOfEating;

            var result = SearchOfTarget(target);
            if (result == 0)
            {
                return false;
            }
            if (result == 1)
            {
                if (target.X >= X && target.X <= RegionOfEatingRight)
                {
                    if (target.HitPoint <= 0)
                    {
                        Eating();
                        PathIsClear = true;
                        return true;
                    }
                    else
                    {
                        target.GetDamage();
                    }
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 1);
                }
            }
            if (result == 2)
            {
                if (target.X <= X && target.X >= RegionOfEatingLeft)
                {
                    if (target.HitPoint <= 0)
                    {
                        Eating();
                        PathIsClear = true;
                        return true;
                    }
                    else
                    {
                        target.GetDamage();
                    }
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 2);
                }
            }
            if (result == 3)
            {
                if (target.Y >= Y && target.Y <= RegionOfEatingDown)
                {
                    if (target.HitPoint <= 0)
                    {
                        Eating();
                        PathIsClear = true;
                        return true;
                    }
                    else
                    {
                        target.GetDamage();
                    }
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 3);
                }
            }
            if (result == 4)
            {
                if (target.Y <= Y && target.Y >= RegionOfEatingUp)
                {
                    if (target.HitPoint <= 0)
                    {
                        Eating();
                        PathIsClear = true;
                        return true;
                    }
                    else
                    {
                        target.GetDamage();
                    }
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 4);
                }
            }
            if (result == 5)
            {
                if ((target.X >= X && target.X <= RegionOfEatingRight) && (target.Y <= Y && target.Y >= RegionOfEatingUp))
                {
                    if (target.HitPoint <= 0)
                    {
                        Eating();
                        PathIsClear = true;
                        return true;
                    }
                    else
                    {
                        target.GetDamage();
                    }
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 5);
                }
            }
            if (result == 6)
            {
                if ((target.X <= X && target.X >= RegionOfEatingLeft) && (target.Y <= Y && target.Y >= RegionOfEatingUp))
                {
                    if (target.HitPoint <= 0)
                    {
                        Eating();
                        PathIsClear = true;
                        return true;
                    }
                    else
                    {
                        target.GetDamage();
                    }
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 6);
                }
            }
            if (result == 7)
            {
                if ((target.X <= X && target.X >= RegionOfEatingLeft) && (target.Y >= Y && target.Y <= RegionOfEatingDown))
                {
                    if (target.HitPoint <= 0)
                    {
                        Eating();
                        PathIsClear = true;
                        return true;
                    }
                    else
                    {
                        target.GetDamage();
                    }
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 7);
                }
            }
            if (result == 8)
            {
                if ((target.X >= X && target.X <= RegionOfEatingRight) && (target.Y >= Y && target.Y <= RegionOfEatingDown))
                {
                    if (target.HitPoint <= 0)
                    {
                        Eating();
                        PathIsClear = true;
                        return true;
                    }
                    else
                    {
                        target.GetDamage();
                    }
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 8);
                }
            }
            return false;
        }
        public bool Eat<E>(int MaxWidthField, int MaxHeightField, E eat, bool a = true) where E : Eat
        {
            int RegionOfEatingLeft, RegionOfEatingRight, RegionOfEatingUp, RegionOfEatingDown;
            RegionOfEatingRight = X + RegionOfEating;
            RegionOfEatingLeft = X - RegionOfEating;
            RegionOfEatingUp = Y - RegionOfEating;
            RegionOfEatingDown = Y + RegionOfEating;

            var result = SearchOfTarget(eat);
            if (result == 0)
            {
                return false;
            }
            if (result == 1)
            {
                if (eat.X >= X && eat.X <= RegionOfEatingRight)
                {
                    Eating();
                    PathIsClear = true;
                    return true;
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 1);
                }
            }
            if (result == 2)
            {
                if (eat.X <= X && eat.X >= RegionOfEatingLeft)
                {
                    Eating();
                    PathIsClear = true;
                    return true;
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 2);
                }
            }
            if (result == 3)
            {
                if (eat.Y >= Y && eat.Y <= RegionOfEatingDown)
                {
                    Eating();
                    PathIsClear = true;
                    return true;
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 3);
                }
            }
            if (result == 4)
            {
                if (eat.Y <= Y && eat.Y >= RegionOfEatingUp)
                {
                    Eating();
                    PathIsClear = true;
                    return true;
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 4);
                }
            }
            if (result == 5)
            {
                if ((eat.X >= X && eat.X <= RegionOfEatingRight) && (eat.Y <= Y && eat.Y >= RegionOfEatingUp))
                {
                    Eating();
                    PathIsClear = true;
                    return true;
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 5);
                }
            }
            if (result == 6)
            {
                if ((eat.X <= X && eat.X >= RegionOfEatingLeft) && (eat.Y <= Y && eat.Y >= RegionOfEatingUp))
                {
                    Eating();
                    PathIsClear = true;
                    return true;
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 6);
                }
            }
            if (result == 7)
            {
                if ((eat.X <= X && eat.X >= RegionOfEatingLeft) && (eat.Y >= Y && eat.Y <= RegionOfEatingDown))
                {
                    Eating();
                    PathIsClear = true;
                    return true;
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 7);
                }
            }
            if (result == 8)
            {
                if ((eat.X >= X && eat.X <= RegionOfEatingRight) && (eat.Y >= Y && eat.Y <= RegionOfEatingDown))
                {
                    Eating();
                    PathIsClear = true;
                    return true;
                }
                else
                {
                    PursuitTarget(MaxWidthField, MaxHeightField, 8);
                }
            }
            return false;
        }
        public void PursuitTarget(int MaxWidthField, int MaxHeightField, int DirectionOfMove)
        {
            if (SettingsGame.rnd.Next(SettingsGame.ChanceOfPursuit) == 1)
            {
                Move(MaxWidthField, MaxHeightField, DirectionOfMove);
                PathIsClear = false;
            }
        }
        public void Run<T>(int MaxWidthField, int MaxHeightField, T enemy) where T : FormOfCell
        {
            var result = SearchOfTarget(enemy);

            if (result == 1)
            {
                Move(MaxWidthField, MaxHeightField, 2);
            }
            if (result == 2)
            {
                Move(MaxWidthField, MaxHeightField, 1);
            }
            if (result == 3)
            {
                Move(MaxWidthField, MaxHeightField, 4);
            }
            if (result == 4)
            {
                Move(MaxWidthField, MaxHeightField, 3);
            }
            if (result == 5)
            {
                Move(MaxWidthField, MaxHeightField, 7);
            }
            if (result == 6)
            {
                Move(MaxWidthField, MaxHeightField, 8);
            }
            if (result == 7)
            {
                Move(MaxWidthField, MaxHeightField, 5);
            }
            if (result == 8)
            {
                Move(MaxWidthField, MaxHeightField, 6);
            }
        }
        public bool Damage<T>(T target) where T : FormOfCell
        {
            int RegionOfEatingLeft, RegionOfEatingRight, RegionOfEatingUp, RegionOfEatingDown;
            RegionOfEatingRight = X + RegionOfEating;
            RegionOfEatingLeft = X - RegionOfEating;
            RegionOfEatingUp = Y - RegionOfEating;
            RegionOfEatingDown = Y + RegionOfEating;
            var result = SearchOfTarget(target);

            if (result == 1)
            {
                if (target.X >= X && target.X <= RegionOfEatingRight)
                {
                    target.GetDamage();
                    return true;
                }
            }
            if (result == 2)
            {
                if (target.X <= X && target.X >= RegionOfEatingLeft)
                {
                    target.GetDamage();
                    return true;
                }
            }
            if (result == 3)
            {
                if (target.Y >= Y && target.Y <= RegionOfEatingDown)
                {
                    target.GetDamage();
                    return true;
                }
            }
            if (result == 4)
            {
                if (target.Y <= Y && target.Y >= RegionOfEatingUp)
                {
                    target.GetDamage();
                    return true;
                }
            }
            if (result == 5)
            {
                if ((target.X >= X && target.X <= RegionOfEatingRight) && (target.Y <= Y && target.Y >= RegionOfEatingUp))
                {
                    target.GetDamage();
                    return true;
                }
            }
            if (result == 6)
            {
                if ((target.X <= X && target.X >= RegionOfEatingLeft) && (target.Y <= Y && target.Y >= RegionOfEatingUp))
                {
                    target.GetDamage();
                    return true;
                }
            }
            if (result == 7)
            {
                if ((target.X <= X && target.X >= RegionOfEatingLeft) && (target.Y >= Y && target.Y <= RegionOfEatingDown))
                {
                    target.GetDamage();
                    return true;
                }
            }
            if (result == 8)
            {
                if ((target.X >= X && target.X <= RegionOfEatingRight) && (target.Y >= Y && target.Y <= RegionOfEatingDown))
                {
                    target.GetDamage();
                    return true;
                }
            }
            return false;
        }
        public void Move(int MaxWidthField, int MaxHeightField, int DirectionOfMove)
        {
            if (PathIsClear == true)
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
            else
            {
                PathIsClear = true;
            }

        }
        public abstract bool IsEvolution();
        public void GetDamage()
        {
            HitPoint--;
        }
        public void Eating()
        {
            CountOfEating++;
        }
        public int SearchOfTarget<T>(T target) where T : ILocation
        {
            int viewRight, viewLeft, viewUp, viewDown;
            viewRight = X + Overview;
            viewLeft = X - Overview;
            viewUp = Y - Overview;
            viewDown = Y + Overview;
            /* цель справа на одной высоте*/
            if (target.X >= X && target.X <= viewRight && target.Y == Y)
            {
                return 1;
            }
            /* цель слева на одной высоте*/
            if (target.X <= X && target.X >= viewLeft && target.Y == Y)
            {
                return 2;
            }
            /* цель снизу на одной ширине */
            if (target.Y >= Y && target.Y <= viewDown && target.X == X)
            {
                return 3;
            }
            /* цель сверху на одной ширине */
            if (target.Y <= Y && target.Y >= viewUp && target.X == X)
            {
                return 4;
            }
            /* цель в первой четверти */
            if ((target.X >= X && target.X <= viewRight) && (target.Y <= Y && target.Y >= viewUp))
            {
                return 5;
            }
            /* цель во второй четверти */
            if ((target.X <= X && target.X >= viewLeft) && (target.Y <= Y && target.Y >= viewUp))
            {
                return 6;
            }
            /* цель в третьей четверти */
            if ((target.X <= X && target.X >= viewLeft) && (target.Y >= Y && target.Y <= viewDown))
            {
                return 7;
            }
            /* цель в четвертой четверти */
            if ((target.X >= X && target.X <= viewRight) && (target.Y >= Y && target.Y <= viewDown))
            {
                return 8;
            }
            return 0;
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