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
    }
}
