﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Link
{
    class arrowProj
    {
        private Vector2 position;
        private int speed = 600;
        private Dir direction;

        public static List<arrowProj> arrowDown = new List<arrowProj>();
        public static List<arrowProj> arrowUp = new List<arrowProj>();
        public static List<arrowProj> arrowLeft = new List<arrowProj>();
        public static List<arrowProj> arrowRight = new List<arrowProj>();

        public arrowProj(Vector2 location, Dir newDir)
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
