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

    class Orientation
    {
        Alis alis;
        bool direct;
    }

    class position
    {

    }

    class position1:position
    {
        Orientation orient1;
    }

    class position2 : position
    {
        Orientation orient1;
        Orientation orient2;
    }

    class position3 : position
    {
        Orientation orient1;
        Orientation orient2;
        Orientation orient3;
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
        int direction;
    }
    class Cube1:Cube
    {
        position1 PositionOriginal;
        position1 PositionNow;
        position1 Direction;
    }
    class Cube2 : Cube
    {

    }
    class Cube3 : Cube
    {

    }
    class RubikCube
    {
        
    }
}
