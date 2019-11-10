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
        private Vector2 position;
        private int speed = 0;
        private Dir direction;

        public static List<BombProj> bomb = new List<BombProj>();

        public BombProj(Vector2 location, Dir newDir)
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

        }
    }
}
