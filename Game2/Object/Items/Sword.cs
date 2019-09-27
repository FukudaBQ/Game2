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

namespace Game2.Object.Items
{
    class Sword : ISprite
    {
        public Vector2 location { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public Shining sprite;
        public Sword(Vector2 location, SpriteBatch batch)
        {
            this.location = location;
            spriteBatch = batch;
            this.sprite = ItemFactory.Instance.CreateSwordSprite();
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
