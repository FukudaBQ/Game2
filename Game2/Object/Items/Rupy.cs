using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Sprites.Link;
using Game2.Factory;

namespace Game2.Object.Items
{
    class Rupy
    {
        public Texture2D texture { get; set; }
        public Vector2 location { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public Shining sprite;
        public Rupy(Vector2 location, SpriteBatch batch)
        {
            this.location = location;
            this.sprite = ItemFactory.Instance.CreateRupySprite();
            spriteBatch = batch;
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