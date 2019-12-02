
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
    class Blocks
    {
        protected Vector2 position;
        protected int Length;
        protected int Width;
        protected Vector2 hitPos;
        private int radius;

        public static List<Blocks> blocks = new List<Blocks>();
        public static List<Blocks> waterblocks = new List<Blocks>();
        public static List<Blocks> upblocks = new List<Blocks>();
        public static List<Blocks> downblocks = new List<Blocks>();
        public static List<Blocks> leftblocks = new List<Blocks>();
        public static List<Blocks> rightblocks = new List<Blocks>();

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

        public Blocks(Vector2 newPos)
        {
            position = newPos;
        }
        
        public static bool didCollide(Vector2 otherPos, int otherL, int otherW)
        {
            foreach(Blocks b in Blocks.blocks)
            {
                int Lsum = b.Length + otherL;
                int Wsum = b.Width + otherW;
                if (Math.Abs(b.hitPos.X - otherPos.X) <=Lsum && Math.Abs(b.hitPos.Y - otherPos.Y) <= Wsum)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool inwater(Vector2 otherPos, int otherL, int otherW)
        {
            foreach (Blocks b in Blocks.waterblocks)
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

    class GeneralBlock:Blocks
    {
        public GeneralBlock(Vector2 newPos) : base(newPos)
        {
            Width = 50;
            Length = 40;
            hitPos = new Vector2(position.X+10, position.Y-10);
        }
    }
}
