﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Link
{
    class Projectile
    {
        private Vector2 position;
        private int speed = 600;
        private Dir direction;


        public static List<Projectile> bomb = new List<Projectile>();
        public static List<Projectile> arrowDown = new List<Projectile>();
        public static List<Projectile> arrowUp = new List<Projectile>();
        public static List<Projectile> arrowLeft = new List<Projectile>();
        public static List<Projectile> arrowRight = new List<Projectile>();
        public static List<Projectile> boomerang = new List<Projectile>();

        public Projectile(Vector2 location, Dir newDir)
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
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

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
