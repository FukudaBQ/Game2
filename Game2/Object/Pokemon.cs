using Game2.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Object
{
    class Pokemon : ISprite
    {
        private Texture2D texture { get; set; }
        public Vector2 location { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public Pokemon(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.texture = texture;
            this.location = location;
            spriteBatch = batch;
        }
        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 282, 178);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 282*3, 178*3);
            spriteBatch.Draw(texture,destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gametime)
        {
        }
    }
}
