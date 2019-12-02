using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.RandomEvent
{
    class SlowDown
    {
        private float timer;
        private Vector2 position;
        public static List<SlowDown> sld = new List<SlowDown>();
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
        public SlowDown(Vector2 position)
        {
            this.position = position;
            timer = 1;
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
