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
    class MoveUp : ISprite
    {
        public Texture2D texture { get; set; }
        public Vector2 location { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        int currentFrame;
        int totalFrame;
        float timeLastUpdate = 0f;
        private GraphicsDeviceManager graphics;
        public MoveUp(Texture2D texture, Vector2 location, SpriteBatch batch, GraphicsDeviceManager graphics)
        {
            this.texture = texture;
            this.location = location;
            spriteBatch = batch;
            currentFrame = 0;
            totalFrame = 2;
            this.graphics = graphics;
        }
        public void Update(GameTime gametime)
        {
            timeLastUpdate += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (timeLastUpdate > 0.5f)
            {
                currentFrame++;
                if (currentFrame == totalFrame)
                {
                    currentFrame = 0;
                }
                timeLastUpdate = 0f;
            }
        }
        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(30 + currentFrame * 30, 0, 15, 25);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 25);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
