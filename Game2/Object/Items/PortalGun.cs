using Game2.Sprites.Blocks;
using Game2.Sprites.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Object.Items
{
    class PortalGun
    {
        private Vector2 position;
        private Vector2 tempPosition;
        private int speed = 1200;
        protected int radius = 10;
        private Dir direction;
        private int monster;
        private float timeLastUpdate = 0f;
        private bool collided = false;

        public static List<PortalGun> portalGuns = new List<PortalGun>();
        public static List<PortalGun> portalGunStoY = new List<PortalGun>();
        public static List<PortalGun> portalGunStoB = new List<PortalGun>();
        public static List<PortalGun> yellowBs = new List<PortalGun>();
        public static List<PortalGun> blueBs = new List<PortalGun>();

        public int Radius
        {
            get { return radius; }
        }
        public int Speed
        {
            get { return speed; }
        }
        public bool Collided
        {
            get { return collided; }
            set { collided = value; }
        }

        public int Monster
        {
            get { return monster; }
            set { monster = value; }
        }

        public PortalGun(Vector2 location, Dir newDir)
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
        public Vector2 TempPosition
        {
            get
            {
                return tempPosition;
            }
        }

        public void Update(GameTime gameTime, Player player)
        {
            int sum = player.Radius + radius;
            if (Vector2.Distance(player.Position, position) < sum)
            {
                portalGuns.RemoveAll(p => p.Radius == 10);
                portalGunStoY.Add(new PortalGun(position, direction));
                portalGunStoB.Add(new PortalGun(position, direction));


            }
        }

        public void ProjUpdate(GameTime gameTime, Player player)
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
            if (Blocks.didCollide(new Vector2(position.X - 5f, position.Y - 5f), 25, 25))
            {
                speed = 0;
                tempPosition = position;
            }
        }




        }
}
