using Game2.Sprites.Enemies;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Link.Projectile
{
    class BombProj
    {
        private float timer;
        private Vector2 position;
        private Dir direction;
        private int currentFrame;
        private int totalFrame;
        private float timeLastUpdate = 0f;
        protected int radius = 10;
        private bool collided = false;

        public static List<BombProj> bomb = new List<BombProj>();

        public BombProj(Vector2 location)
        {
            position = location;
            Timer = 1;

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
        public float Timer
        {
            get { return timer; }
            set { timer = value; }
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
        }
    }
}
