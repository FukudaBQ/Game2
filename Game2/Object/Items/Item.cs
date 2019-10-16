using Game2.Factory;
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
    class Item
    {
        private Vector2 position;
        private SpriteBatch spriteBatch;
        protected Shining sprite;
        private bool collided = false;
        protected int speed;
        protected int radius;

        public static List<Item> items = new List<Item>();

        public Item(Vector2 newPos, SpriteBatch spriteBatch)
        {
            position = newPos;
            this.spriteBatch = spriteBatch;
            
        }

        public void Update(GameTime gameTime)
        {
            this.sprite.Update(gameTime);
        }
        public void Draw()
        {
            this.sprite.Draw(spriteBatch, position);
        }
        public bool Collided
        {
            get { return collided; }
            set { collided = value; }
        }

        public int Radius
        {
            get { return radius; }
          
        }


        public Vector2 Position
        {
            get { return position; }
        }
        public void setX(float newX)
        {
            position.X = newX;
        }
        public void setY(float newY)
        {
            position.Y = newY;
        }
    }


    class Fairy2 : Item
    {
        public Fairy2(Vector2 newPos,SpriteBatch spriteBatch):base(newPos, spriteBatch)
        {
            speed = 100;
            radius = 10;
            sprite = ItemFactory.Instance.CreateFariySprite();
        }
    }

}
