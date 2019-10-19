
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
        protected int radius;
        protected Vector2 hitPos;

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
        
        public static bool didCollide(Vector2 otherPos, int otherRad)
        {
            foreach(Blocks b in Blocks.blocks)
            {
                int sum = b.Radius + otherRad;
                if (Vector2.Distance(b.hitPos, otherPos) < sum)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool inwater(Vector2 otherPos, int otherRad)
        {
            foreach (Blocks b in Blocks.waterblocks)
            {
                int sum = b.Radius + otherRad;
                if (Vector2.Distance(b.hitPos, otherPos) < sum)
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
            radius = 50;
            hitPos = new Vector2(position.X-2, position.Y);
        }
    }
}
