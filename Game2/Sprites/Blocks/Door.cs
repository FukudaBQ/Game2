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

        public static List<Door> doors = new List<Door>();

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

        public static bool didCollide(Vector2 otherPos, int otherL, int otherW)
        {
            foreach (Door d in Door.doors)
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
