using Game2.Factory;
using Game2.Interfaces;
using Game2.Sprites.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Items
{
    class Map : ISprite
    {
        public Vector2 location { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        private Shining sprite;
        public Map(Vector2 location, SpriteBatch batch)
        {
            this.location = location;
            spriteBatch = batch;
            sprite = ItemFactory.Instance.CreateMapSprite();
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gametime)
        {
        }
    }
}
