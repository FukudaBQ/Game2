using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Blocks
{
    class Rock
    {
        protected Vector2 position;
        protected int radius=65;
        protected int Length;
        protected int Width;
        protected Vector2 hitPos;
        protected int health = 1;

        public static List<Rock> rocks = new List<Rock>();

        public Vector2 HitsPos
        {
            get { return hitPos; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }


        public Vector2 Position
        {
            get { return position; }
        }

        public int Radius
        {
            get { return radius; }
        }

        public Rock(Vector2 newPos)
        {
            position = newPos;
        }

        public static bool didCollide(Vector2 otherPos, int otherL, int otherW)
        {
            foreach (Rock b in Rock.rocks)
            {
                int Lsum = b.Length + otherL;
                int Wsum = b.Width + otherW;
                if (Math.Abs(b.hitPos.X - otherPos.X) <= Lsum && Math.Abs(b.hitPos.Y - otherPos.Y) <= Wsum)
                {
                    return true;
                }
            }
            return false;
        }
    }
    class RockBlock : Rock
    {
        public RockBlock(Vector2 newPos) : base(newPos)
        {
            Width = 50;
            Length = 40;
            hitPos = new Vector2(position.X + 10, position.Y - 10);
        }
    }
}
