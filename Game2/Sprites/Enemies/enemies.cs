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
        }
    }
    class Dragons : Enemies {
        public Dragons(Vector2 newPos) : base(newPos) {
            speed = 80;
        }
    }
}
