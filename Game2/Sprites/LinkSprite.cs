using Game2.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites
{
    class LinkSprite : ISprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Vector2 position;
        private int x = 1;
        private int y = 1;
        private int width = 15;
        private int height = 25;
        public LinkSprite(Texture2D texture, SpriteBatch spriteBatch, Vector2 position)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            this.position = position;
        }
        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(x, y, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
        }
        
    }
}
