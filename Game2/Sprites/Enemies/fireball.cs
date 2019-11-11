using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Enemies
{
    class fireball
    {
        private Vector2 position;
        private int speed = 300;
        protected int radius = 15;
        private Dir direction;
        private bool collided = false;
        private float timer = 2;

        public static List<fireball> fireDown = new List<fireball>();
        public static List<fireball> fireUp = new List<fireball>();
        public static List<fireball> fireLeft = new List<fireball>();
        public float Timer
        {
            get { return timer; }
            set { timer = value; }
        }
        public int Radius
        {
            get { return radius; }
        }
        public bool Collided
        {
            get { return collided; }
            set { collided = value; }
        }

        public fireball(Vector2 location, Dir newDir)
        {
            position = location;
            direction = newDir;

        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }
        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > 0)
            {
                timer -= dt;
            }

                switch (direction)
            {
                case Dir.Left:
                    position.X -= speed * dt;
                    break;
                case Dir.Up:
                    position.X -= speed * dt;
                    position.Y -= speed * dt;
                    break;
                case Dir.Down:
                    position.X -= speed * dt;
                    position.Y += speed * dt;
                    break;
                default:
                    break;
            }
        }
    }
}
