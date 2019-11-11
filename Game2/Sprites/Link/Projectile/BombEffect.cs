using Game2.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Projectile
{
    class BombEffect
    {
        private Texture2D texture { get; set; }
        private Vector2 location { get; set; }
        private SpriteBatch spriteBatch { get; set; }
        private int currentFrame;
        private int totalFrame;
        private float timeLastUpdate = 0f;
        public Color color = Color.White;
        public BombEffect(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.texture = texture;
            this.location = location;
            spriteBatch = batch;
            currentFrame = 0;
            totalFrame = 2;
        }
        public void Update(GameTime gametime)
        {
            timeLastUpdate += (float)gametime.ElapsedGameTime.TotalSeconds;
            while (timeLastUpdate <= 1.2f)
            {
                if (timeLastUpdate > 0.6f)
                {
                    currentFrame++;
                    if (currentFrame == totalFrame)
                    {
                        currentFrame = 0;
                    }
                }
            }
        }
        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(0 + currentFrame * 30, 0, 18, 18);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16 * 4, 16 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}