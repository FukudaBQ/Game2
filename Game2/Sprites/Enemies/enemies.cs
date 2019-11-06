using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Enemies
{
    class Enemies
    {
        private Vector2 position;
        protected int health;
        protected int speed;
        protected int radius;
        private bool collided = false;

        public static List<Enemies> enemies = new List<Enemies>();

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public Vector2 Position
        {
            get { return position; }
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

        public void setX(float newX)
        {
            position.X = newX;
        }
        public void setY(float newY)
        {
            position.Y = newY;
        }
        public Enemies(Vector2 newPos)
        {
            position = newPos;
        }

        public void Update(GameTime gameTime,Vector2 playerPos)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 moveDir = playerPos - position;
            moveDir.Normalize();
            position += moveDir*speed*dt;
        }
    }

    class Bats : Enemies {
        public Bats(Vector2 newPos) : base(newPos) {
            speed = 160;
            radius = 10;
            health = 1;
        }
    }
    class Hands : Enemies {
        public Hands(Vector2 newPos) : base(newPos) {
            speed = 80;
            radius = 15;
            health = 2;
        }
    }
    class Knights : Enemies
    {
        public Knights(Vector2 newPos) : base(newPos)
        {
            speed = 80;
            radius = 15;
            health = 2;
        }
    }
    class Monsters : Enemies
    {
        public Monsters(Vector2 newPos) : base(newPos)
        {
            speed = 80;
            radius = 15;
            health = 3;
        }
    }
    /*class Stalfoses : Enemies
    {
        public Stalfoses(Vector2 newPos) : base(newPos)
        {
            speed = 80;
            radius = 15;
            health = 2;
        }
    }*/
}
