using Game2.Sprites.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Factory
{
    class ItemFactory
    {
        private Texture2D item;
        private Texture2D NPC;
        private Vector2 hitPos;
        private int radius;
        public static ItemFactory instance = new ItemFactory();
        public static List<ItemFactory> items = new List<ItemFactory>();

        public int Radius
        {
            get
            {
                return radius;

            }
        }
        public Vector2 HitsPos
        {
            get
            {
                return hitPos;
            }
        }
        public static ItemFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private ItemFactory()
        {
        }
        public static bool collide(Vector2 otherPos, int otherRad)
        {
            foreach (ItemFactory i in ItemFactory.items)
            {
                int sum = i.Radius + otherRad;
                if (Vector2.Distance(i.hitPos, otherPos) < sum)
                {
                    return true;
                }

            }
            return false;
        }
        public void LoadAllTextures(ContentManager content)
        {
            item = content.Load<Texture2D>("Item");
            NPC = content.Load<Texture2D>("NPC");
        }
        public Shining CreateRupySprite()
        {
            return new Shining(item, 164, 100, 20, 36, 40);
        }
        public Shining CreateTriforceSprite()
        {
            return new Shining(item, 318, 100, 20, 36, 20);
        }
        public Shining CreateFariySprite()
        {
            return new Shining(item, 123, 40, 20, 36, 40);
        }
        public Shining CreateKeySprite()
        {
            return new Shining(item, 280, 40, 20, 40, 0);
        }
        public Shining CreateClockSprite()
        {
            return new Shining(item, 360, 0, 13, 40, 0);
        }
        public Shining CreateArrowSprite()
        {
            return new Shining(item, 30, 40, 20, 40, 0);
        }
        public Shining CreateSwordSprite()
        {
            return new Shining(item, 280, 100, 20, 40, 0);
        }
        public Shining CreateOldManSprite()
        {
            return new Shining(NPC, 0, 1, 20, 36, 30);
        }
        public Shining CreateMapSprite()
        {
            return new Shining(item, 240, 60, 20, 40, 0);
        }
        public Shining CreateHeartConttainerSprite()
        {
            return new Shining(item, 240, 40, 20, 40, 0);
        }
        public Shining CreateCompassSprite()
        {
            return new Shining(item, 80, 40, 20, 40, 0);
        }
        public Shining CreateBowSprite()
        {
            return new Shining(item, 320, 0, 13, 40, 0);
        }
        public Shining CreateRingSprite()
        {
            return new Shining(item, 117, 100, 20, 40, 0);
        }
        public Shining CreateMagicKeySprite()
        {
            return new Shining(item, 164, 80, 20, 40, 0);
        }
        public Shining CreateLadderSprite()
        {
            return new Shining(item, 320, 40, 20, 40, 0);
        }
        public Shining CreateRaftSprite()
        {
            return new Shining(item, 320, 80, 20, 40, 0);
        }
        public Shining CreateBombSprite()
        {
            return new Shining(item, 200, 0, 13, 40, 0);
        }
        public Shining CreateBoomerangSprite()
        {
            return new Shining(item, 283, 0, 13, 30, 0);
        }
    }
}
