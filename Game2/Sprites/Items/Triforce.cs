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
    class Triforce
    {
        public Texture2D texture { get; set; }
        public Vector2 location { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public Shining sprite;
        public Triforce(Vector2 location, SpriteBatch batch)
        {
            this.location = location;
            spriteBatch = batch;
            sprite = ItemFactory.Instance.CreateTriforceSprite();
        }
        public void Update(GameTime gametime)
        {
            sprite.Update(gametime);
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
