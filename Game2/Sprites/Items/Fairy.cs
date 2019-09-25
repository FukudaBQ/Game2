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
    class Fairy
    {
        public Vector2 location { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public Shining sprite;
        public Fairy(Vector2 location, SpriteBatch batch)
        {
            this.location = location;
            this.sprite = ItemFactory.Instance.CreateFariySprite();
            this.spriteBatch = batch;
        }
        public void Update(GameTime gameTime)
        {
            this.sprite.Update(gameTime);
        }
        public void Draw()
        {
            this.sprite.Draw(spriteBatch, location);
        }
    }
}
