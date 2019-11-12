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
    class Dragon
    {
        private Texture2D texture { get; set; }
        private Vector2 location;
        private bool movingUp = false;
        private SpriteBatch spriteBatch { get; set; }
        private int currentFrame;
        protected int health = 3;
        public Color color = Color.White;
        protected int radius = 50;
        private KeyboardState previous = Keyboard.GetState();
        private int totalFrame;
        private float timeLastUpdate = 0f;
        protected int speed = 80;
        public static List<Dragon> dragons = new List<Dragon>();
        private float timer = 2;
        private float healthTimer = 1;
        public float HealthTimer
        {
            get { return healthTimer; }
            set { healthTimer = value; }
        }
        public Color Dcolor
        {
            get { return color; }
            set { color = value; }
        }
        public float Timer
        {
            get { return timer; }
            set { timer = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int Radius
        {
            get { return radius; }
        }
        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
        public Dragon(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.texture = texture;
            this.location = location;
            spriteBatch = batch;
            currentFrame = 0;
            totalFrame = 4;
        }
        public void Update(GameTime gametime)
        {
            float dt = (float)gametime.ElapsedGameTime.TotalSeconds;
            if (healthTimer > 0)
            {
                healthTimer -= dt;
            }
            timeLastUpdate += (float)gametime.ElapsedGameTime.TotalSeconds;
            if (timer > 0)
            {
                timer -= dt;
            }

            if (timeLastUpdate > 0.2f)
            {
                currentFrame++;
                if (currentFrame == totalFrame)
                {
                    currentFrame = 0;
                }
                timeLastUpdate = 0f;
            }
            if (movingUp)
            {
                location.Y += speed * dt;
            }
            else
            {
                location.Y -= speed * dt;
            }
            if(location.Y >= 4540)
            {
                movingUp = false;
            }
            else if (location.Y <= 4240)
            {
                movingUp = true;
            }


        }
        public void Draw(Vector2 location)
        {
            
            Rectangle sourceRectangle = new Rectangle(currentFrame * 41, 1, 45, 46);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 41 * 4, 46 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
