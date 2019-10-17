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
    class Map : ISprite
    {
        public Vector2 location { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        private Shining sprite;
        private Texture2D texture;
        private int x = 123, y = 40, width = 20, height = 36, frameDistance = 40;
        private int currentFrame = 0, totalFrame = 2;
        private float timeLastUpdate = 0f;
        public Map(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.location = location;
            spriteBatch = batch;
            //sprite = ItemFactory.Instance.CreateMapSprite();
            this.texture = texture;
        }
        public void Draw()
        {
            //sprite.Draw(spriteBatch, location);
            Rectangle sourceRectangle = new Rectangle(x + currentFrame * frameDistance, y, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 20 * 4, 40 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
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
    }
}
