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
    class Key : ISprite
    {
        /*public Vector2 location { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public Shining sprite;
        //private KeyStateMachine stateMachine;
        public Key(Vector2 location, SpriteBatch batch)
        {
            this.location = location;
            spriteBatch = batch;
            sprite = ItemFactory.Instance.CreateKeySprite();
        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gametime)
        {

        }*/
        public Texture2D texture { get; set; }
        public Vector2 location { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public Rectangle destinationRectangle;
        public Key(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.texture = texture;
            this.location = location;
            spriteBatch = batch;
        }
        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(280, 40, 20, 40);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 20 * 4, 40 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White*0);
        }

        public void Update(GameTime gametime)
        {
        }
    }

    class KeyStateMachine
    {
        public int ifCollected = 0;
        public Vector2 Location;
        public KeyStateMachine(Vector2 location)
        {
            this.Location = location;
        }
        public void ChangeIfCollected()
        {
            ifCollected = 1;
        }
    }
}
