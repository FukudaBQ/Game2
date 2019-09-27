using Game2.Sprites.Link;
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
        public static ItemFactory instance = new ItemFactory();
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
    }
}
