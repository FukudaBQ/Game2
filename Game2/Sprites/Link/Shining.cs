using Game2.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Link
{
    class Shining
    {
        public Texture2D texture;
        private int currentFrame;
        private int totalFrame;
        private float timeLastUpdate = 0f;
        private int x;
        private int y;
        private int width;
        private int height;
        private int frameDistance;
        public Shining(Texture2D texture, int x, int y, int width, int height, int frameDistance)
        {
            this.texture = texture;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.frameDistance = frameDistance;
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

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(x + currentFrame * frameDistance, y, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 20 * 4, 40 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
