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

    public enum Alis
    {
        X,
        Y,
        Z
    }
    /// <summary>
    /// 用来表示方向
    /// 分为：正方向、负方向、零方向
    /// </summary>
    public enum AlisDirection
    {
        /// <summary>
        /// 正方向
        /// </summary>
        Plus = 1,
        /// <summary>
        /// 负方向
        /// </summary>
        Minus = -1,
        /// <summary>
        /// 零方向
        /// </summary>
        Zero = 0
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

    public class Orient{
        public Alis ali;
        public AlisDirection direc;
        public Orient(Alis a,AlisDirection d)
        {
            ali = a;
            direc = d;
        }
        public Orient()
        {
            ali = Alis.X;
            direc = AlisDirection.Zero;
        }
        public Orient(Orient o)
        {
            this.ali = o.ali;
            this.direc = o.direc;
        }
        public override string ToString()
        {
            string str = "";
            switch(ali)
            {
                case Alis.X:
                    str += "X : ";
                    break;
                case Alis.Y:
                    str += "Y : ";
                    break;
                case Alis.Z:
                    str += "Z : ";
                    break;
            }
            switch(direc)
            {
                case AlisDirection.Minus:
                    str += "-";
                    break;
                case AlisDirection.Plus:
                    str += "+";
                    break;
                case AlisDirection.Zero:
                    str += "0";
                    break;
            }
            return str;
        }
    }

    public class CubePosition
    {
        List<Orient> orientList;

        public CubePosition()
        {
            orientList = new List<Orient>();
            orientList.Add(new Orient());
            orientList.Add(new Orient());
            orientList.Add(new Orient());
            this.X = new Orient(Alis.X,AlisDirection.Plus);
            this.Y = new Orient(Alis.Y, AlisDirection.Plus);
            this.Z = new Orient(Alis.Z, AlisDirection.Plus);
        }

        public CubePosition(Orient x, Orient y, Orient z)
        {
            orientList = new List<Orient>();
            orientList.Add(new Orient());
            orientList.Add(new Orient());
            orientList.Add(new Orient());
            this.X = new Orient(x);
            this.Y = new Orient(y);
            this.Z = new Orient(z);
        }


        public Orient X
        {
            get
            {
                return orientList[0];
            }
            set
            {
                orientList[0] = value;
            }
        }
        public Orient Y
        {
            get
            {
                return orientList[1];
            }
            set
            {
                orientList[1] = value;
            }
        }
        public Orient Z
        {
            get
            {
                return orientList[2];
            }
            set
            {
                orientList[2] = value;
            }
        }

        public override string ToString()
        {
            string str = "方块位置：\n\r";
            foreach(Orient o in orientList)
            {
                str += o.ToString();
                str += "\n\r";
            }
            return str + "\n\r";
        }
    }

    public class MyCube
    {
        public CubePosition origin;

        public MyCube(CubePosition pos)
        {
            origin = pos;
        }
    }

    public class MyRubikCube
    {
        public List<MyCube> listCube = new List<MyCube>(27);
        public void InitRubikCube()
        {
            for(int i=0;i<27;++i)
            {
                int x = i / 9;
                int y = (i - x * 9)/3;
                int z = i - x * 9 - y * 3;

                Orient dx = new Orient(Alis.X,(AlisDirection)(x - 1));
                Orient dy = new Orient(Alis.Y, (AlisDirection)(y - 1));
                Orient dz = new Orient(Alis.Z, (AlisDirection)(z - 1));

                CubePosition pos = new CubePosition(dx, dy, dz);

                listCube.Add(new MyCube(pos));
            }
        }
    }
}
