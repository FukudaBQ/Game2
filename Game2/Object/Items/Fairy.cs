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
    class Fairy
    {
        public Vector2 location { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public Shining sprite;
        private Texture2D texture;
        private int x = 123, y = 40, width = 20, height = 36, frameDistance = 40;
        private int currentFrame = 0, totalFrame = 2;
        private float timeLastUpdate = 0f;
        private bool collided = false;

        private int radius = 10;

        public bool Collided
        {
            get { return collided; }
            set { collided = value; }
        }
        public static List<Fairy> fairies = new List<Fairy>();

        public int Radius
        {
            get { return radius; }
        }

        public Fairy(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.location = location;
            //this.sprite = ItemFactory.Instance.CreateFariySprite();
            this.texture = texture;
            this.spriteBatch = batch;
        }
        public void Update(GameTime gameTime)
        {
            //this.sprite.Update(gameTime);
            timeLastUpdate += (float)gameTime.ElapsedGameTime.TotalSeconds;

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
        public void Draw()
        {
            //this.sprite.Draw(spriteBatch, location);
            Rectangle sourceRectangle = new Rectangle(x + currentFrame * frameDistance, y, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 20 * 4, 40 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
