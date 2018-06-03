using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikCube.Classes
{
    enum Direction
    {
        Ahead,
        Back,
        Left,
        Right,
        Up,
        Down
    }

    enum Alis
    {
        X,
        Y,
        Z
    }

    /// <summary>
    /// 方向
    /// 分为X,Y,Z三条轴
    /// 和
    /// 正，负两个方向
    /// </summary>
    class Orientation
    {
        public Alis alis;
        public bool direct;
        public Orientation(Alis a,bool di)
        {
            alis = a;
            direct = di;
        }

        public object Clone()
        {
            return new Orientation(this.alis, this.direct);
        }
        public static bool operator ==(Orientation or1,Orientation or2)
        {
            if(or1.alis==or2.alis&&or1.direct==or2.direct)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Orientation or1, Orientation or2)
        {
            if (or1.alis != or2.alis || or1.direct != or2.direct)
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object obj)
        {
            if(obj==null)
            {
                return false;
            }
            Orientation or2 = obj as Orientation;
            if((System.Object)or2 == null)
            {
                return false;
            }
            if (this.alis == or2.alis && this.direct == or2.direct)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 判断是否是当前方向的反方向
        /// </summary>
        /// <param name="or2">被判断方向</param>
        /// <returns></returns>
        public bool isOppositeDrectionOf(Orientation or2)
        {
            if(this.alis == or2.alis&&(!this.direct)==or2.direct)
            {
                return true;
            }
            return false;
        }
    }

    class position
    {

    }

    class position1:position
    {
        public Orientation orient1;
    }

    class position2 : position
    {
        public Orientation orient1;
        public Orientation orient2;
    }

    class position3 : position
    {
        public Orientation orient1;
        public Orientation orient2;
        public Orientation orient3;
    }


    class Face
    {
        /// <summary>
        /// 包含的方块
        /// </summary>
        List<Cube> Cubes;

        /// <summary>
        /// 位置
        /// </summary>
        position1 Location;
        /// <summary>
        /// 顺时针转动
        /// </summary>
        public void RotateClockwise()
        {

        }
        /// <summary>
        /// 逆时针转动
        /// </summary>
        public void RotateAntiClockwise()
        {

        }
    }
    class Cube
    {
        public virtual bool MoveTo_OneSkip(position p){
            return true;
        }
    }
    class Cube1:Cube
    {
        position1 PositionOriginal;
        position1 PositionNow;
        position1 Direction;
    }
    class Cube2 : Cube
    {
        position2 PositionOriginal;
        position2 PositionNow;
        position2 Direction;

        public override bool MoveTo_OneSkip(position p)
        {
            if (p is Classes.position2)
            {
                position2 pTo = p as position2;
                Orientation stand = null;
                Orientation left1 = null;
                Orientation left2 = null;

                if(PositionNow.orient1==pTo.orient1)
                {
                    stand = PositionNow.orient1.Clone() as Orientation;
                    left1 = PositionNow.orient2.Clone() as Orientation;
                    left2 = pTo.orient2.Clone() as Orientation;
                }
                else if (PositionNow.orient1 == pTo.orient2)
                {
                    stand = PositionNow.orient1.Clone() as Orientation;
                    left1 = PositionNow.orient2.Clone() as Orientation;
                    left2 = pTo.orient1.Clone() as Orientation;
                }
                else if (PositionNow.orient2 == pTo.orient1)
                {
                    stand = PositionNow.orient2.Clone() as Orientation;
                    left1 = PositionNow.orient1.Clone() as Orientation;
                    left2 = pTo.orient2.Clone() as Orientation;
                }
                else if (PositionNow.orient2 == pTo.orient2)
                {
                    stand = PositionNow.orient2.Clone() as Orientation;
                    left1 = PositionNow.orient1.Clone() as Orientation;
                    left2 = pTo.orient1.Clone() as Orientation;
                }
                if(left1==null||left2==null)
                {
                    return false;
                }
                else
                {
                    if(left1==left2||left1.isOppositeDrectionOf(left2))
                    {
                        return false;
                    }
                    else
                    {

                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
    class Cube3 : Cube
    {
        position3 PositionOriginal;
        position3 PositionNow;
        position3 Direction;
    }
    class RubikCube
    {
        
    }
}
