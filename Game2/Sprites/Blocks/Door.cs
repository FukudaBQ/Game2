using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Blocks
{
    class Door
    {
        protected Vector2 position;
        protected int Length;
        protected int Width;
        protected Vector2 hitPos;
        private int radius;
        protected int health = 1;

        public static List<Door> leftdoors = new List<Door>();
        public static List<Door> downdoors = new List<Door>();
        public static List<Door> rightdoors = new List<Door>();
        public static List<Door> leftdoors2 = new List<Door>();
        public static List<Door> updoors = new List<Door>();

        public Vector2 HitsPos
        {
            get { return hitPos; }
        }


        public Vector2 Position
        {
            get { return position; }
        }

        public int Radius
        {
            get { return radius; }
        }

        public Door(Vector2 newPos)
        {
            position = newPos;
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public static bool didCollideLeft(Vector2 otherPos, int otherL, int otherW)
        {
            foreach (Door d in Door.leftdoors)
            {
                int Lsum = d.Length + otherL;
                int Wsum = d.Width + otherW;
                if (Math.Abs(d.hitPos.X - otherPos.X) <= Lsum && Math.Abs(d.hitPos.Y - otherPos.Y) <= Wsum)
                {
                    return true;
                }
            }
            return false;

        }
        public static bool didCollideLeft2(Vector2 otherPos, int otherL, int otherW)
        {
            foreach (Door d in Door.leftdoors2)
            {
                int Lsum = d.Length + otherL;
                int Wsum = d.Width + otherW;
                if (Math.Abs(d.hitPos.X - otherPos.X) <= Lsum && Math.Abs(d.hitPos.Y - otherPos.Y) <= Wsum)
                {
                    return true;
                }
            }
            return false;

        }
        public static bool didCollideUp(Vector2 otherPos, int otherL, int otherW)
        {
            foreach (Door d in Door.updoors)
            {
                int Lsum = d.Length + otherL;
                int Wsum = d.Width + otherW;
                if (Math.Abs(d.hitPos.X - otherPos.X) <= Lsum && Math.Abs(d.hitPos.Y - otherPos.Y) <= Wsum)
                {
                    return true;
                }
            }
            return false;

        }
        public static bool didCollideRight(Vector2 otherPos, int otherL, int otherW)
        {
            foreach (Door d in Door.rightdoors)
            {
                int Lsum = d.Length + otherL;
                int Wsum = d.Width + otherW;
                if (Math.Abs(d.hitPos.X - otherPos.X) <= Lsum && Math.Abs(d.hitPos.Y - otherPos.Y) <= Wsum)
                {
                    return true;
                }
            }
            return false;

        }
        public static bool didCollideDown(Vector2 otherPos, int otherL, int otherW)
        {
            foreach (Door d in Door.downdoors)
            {
                int Lsum = d.Length + otherL;
                int Wsum = d.Width + otherW;
                if (Math.Abs(d.hitPos.X - otherPos.X) <= Lsum && Math.Abs(d.hitPos.Y - otherPos.Y) <= Wsum)
                {
                    return true;
                }
            }
            return false;

        }

    }

    class Doors : Door
    {
        public Doors(Vector2 newPos) : base(newPos)
        {
            Width = 50;
            Length = 40;
            hitPos = new Vector2(position.X + 10, position.Y - 10);
        }
    }
}
