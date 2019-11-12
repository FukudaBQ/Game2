using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Link
{
    class BoomerangProj
    {
        private Vector2 position;
        private int speed = 10;
        private Dir direction;
        private bool movingRight=true;
        private float timeLastUpdate = 0f;
        private float timer;
        public static List<BoomerangProj> boomerang = new List<BoomerangProj>();

        public float Timer
        {
            get { return Timer; }
            set { Timer = value; }
        }
        public BoomerangProj(Vector2 location, Dir newDir)
        {
            position = location;
            direction = newDir;
            timer = 1;
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
            
            //timeLastUpdate += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //if (timeLastUpdate > 1.0f)
            //{
            //    movingRight = true;
            //}
            //else
            //{
               // movingRight = false;

            //}


            switch (direction)
            {
                case Dir.Right:
                    position.X += speed*timer;
                    if (timer <= 0)
                    {
                        timer += dt;
                        position.X -= speed * timer * 30;
                    }
                    //position.X += speed * dt;
                    //if (movingRight)
                    //{
                    //    position.X -= speed * dt;
                    //}
                    //else
                    //{
                     //   position.X += speed * dt;
                    //}
                    break;
                case Dir.Left:
                    position.X -= speed * dt;
                    break;
                case Dir.Up:
                    position.Y -= speed * dt;
                    break;
                case Dir.Down:
                    position.Y += speed * dt;
                    break;
                default:
                    break;
            }
        }
    }
}
