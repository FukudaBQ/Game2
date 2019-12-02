using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Link
{
    class ArrowProj
    {
        private Vector2 position;
        private int speed = 600;
        protected int radius = 10;
        private Dir direction;
        private bool collided = false;
        private float blackHoleTimer = 0f;

        public static List<ArrowProj> arrowDown = new List<ArrowProj>();
        public static List<ArrowProj> arrowUp = new List<ArrowProj>();
        public static List<ArrowProj> arrowLeft = new List<ArrowProj>();
        public static List<ArrowProj> arrowRight = new List<ArrowProj>();

        public float BlackHoleTimer
        {
            get { return blackHoleTimer; }
            set { blackHoleTimer = value; }
        }
        public int Radius
        {
            get { return radius; }
        }
        public bool Collided
        {
            get { return collided; }
            set { collided=value; }
        }

        public ArrowProj(Vector2 location, Dir newDir)
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
            set { position = value; }
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            blackHoleTimer -= dt;
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
        }
    }
}
