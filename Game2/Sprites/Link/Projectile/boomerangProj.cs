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
        private int speed = 500;
        private Dir direction;
        private bool movingRight=true;
        private float timeLastUpdate = 0f;
        private float timer = 0f;
        private bool isBack = false;
        public static List<BoomerangProj> boomerang = new List<BoomerangProj>();
        public int Speed
        {
            get { return speed; }
        }
        public float Timer
        {
            get { return Timer; }
            set { Timer = value; }
        }
        public bool IsBack
        {
            get { return isBack; }
            set { isBack = value; }
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

        public void Update(GameTime gameTime,Player player)
        {
            
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeLastUpdate += (float)gameTime.ElapsedGameTime.TotalSeconds;
            switch (direction)
            {
                case Dir.Right:

                    position.X += speed * dt;

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

            if (timeLastUpdate > 1.0f)
            {
                Vector2 moveDir = player.Position - position;
                moveDir.Normalize();
                position += moveDir * 800 * dt;
            }
        }
    }
}
