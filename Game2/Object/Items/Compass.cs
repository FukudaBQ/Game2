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
    class Compass : ISprite
    {
        public Texture2D texture { get; set; }
        public Vector2 location { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        private Shining sprite;
        public Compass(Vector2 location, SpriteBatch batch)
        {
            sprite = ItemFactory.Instance.CreateCompassSprite();
            this.location = location;
            spriteBatch = batch;
        }
        public void Draw()
        {
            /*Rectangle sourceRectangle = new Rectangle(80, 40, 20, 40);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 20 * 4, 40 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);*/
            sprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gametime)
        {
        }
    }
}
