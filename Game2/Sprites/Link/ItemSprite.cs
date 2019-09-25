using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Link
{
    class ItemSprite
    {
        public Texture2D texture;
        private int rows;
        private int columns;
        private int currentFrame;
        private int totalFrame;
        private float timeLastUpdate = 0f;
        public ItemSprite(Texture2D texture, int rows, int columns)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            currentFrame = 0;
            totalFrame = 2;
        }

        public void Update(GameTime gametime)
        {
            timeLastUpdate += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (timeLastUpdate > 0.2f)
            {
                currentFrame++;
                if (currentFrame == totalFrame)
                {
                    currentFrame = 0;
                }
                timeLastUpdate = 0f;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, int a, int b, int c, int d, int e)
        {
            Rectangle sourceRectangle = new Rectangle(a + currentFrame * e, b, c, d);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 20 * 4, 40 * 4);
            spriteBatch.Draw(texture, sourceRectangle, destinationRectangle, Color.White);
        }


    }
}
