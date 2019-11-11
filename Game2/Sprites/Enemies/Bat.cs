using Game2.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Enemies
{
    class Bat
    {
        private Texture2D texture { get; set; }
        public Vector2 location { get; set; }
        private SpriteBatch spriteBatch { get; set; }
        private bool hitted=true;
        public Color color = Color.White;
        private KeyboardState previous = Keyboard.GetState();
        private int currentFrame;
        private int totalFrame;
        private float timeLastUpdate = 0f;
        protected int health;
        protected int speed=80;
        protected int radius=10;
        public static List<Bat> bats = new List<Bat>();
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int Radius
        {
            get { return radius; }
        }
        public Bat(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.texture = texture;
            this.location = location;
            spriteBatch = batch;
            currentFrame = 0;
            totalFrame = 2;
        }
        public void Update(GameTime gametime, Vector2 playerPos)
        {
            float dt = (float)gametime.ElapsedGameTime.TotalSeconds;

            timeLastUpdate += dt;

            if (timeLastUpdate > 0.2f)
            {
                currentFrame++;
                if (currentFrame == totalFrame)
                {
                    currentFrame = 0;
                }
                timeLastUpdate = 0f;
            }
            
            Vector2 moveDir = playerPos - location;
            moveDir.Normalize();
            location += moveDir * speed * dt;
        }
        public void Draw(Vector2 Location)
        {

            Rectangle sourceRectangle = new Rectangle(4+currentFrame*24, 6, 16, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16 * 4, 16 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
