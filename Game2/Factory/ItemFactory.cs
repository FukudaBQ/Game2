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
        public Shining CreateRupySprite(int rows, int columns)
        {
            return new Shining(item, rows, columns, 164, 100, 20, 36, 40);
        }
        public Shining CreateTriforceSprite(int rows, int columns)
        {
            return new Shining(item, rows, columns, 318, 100, 20, 36, 20);
        }
        public Shining CreateFariySprite(int rows, int columns)
        {
            return new Shining(item, rows, columns, 123, 40, 20, 36, 40);
        }
    }
}
