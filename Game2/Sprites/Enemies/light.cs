using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Enemies
{
    class light
    {
        private float timer;
        private Vector2 position;
        protected int radius = 80;
        private bool collided = false;
        public static List<light> lig = new List<light>();
        public float Timer
        {
            get { return timer; }
            set { timer = value; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
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
        public light(Vector2 position)
        {
            this.position = position;
            timer = 1.5f;
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
