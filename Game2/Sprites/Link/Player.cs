using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2.Sprites.Link
{
    class Player
    {
        private Vector2 position = new Vector2(100, 100);
        private int speed = 200;
        private Dir direction = Dir.Down;
        private bool isMoving = false;
        public MoveDown anim;
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }
        public void setX(float newX)
        {
            position.X = newX;
        }
        public void setY(float newY)
        {
            position.Y = newY;
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState kState = Keyboard.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //anim.Update();
            isMoving = false;
            if (kState.IsKeyDown(Keys.A)|| kState.IsKeyDown(Keys.Left))
            {
                direction = Dir.Right;
                isMoving = true;
            }
            if (kState.IsKeyDown(Keys.D)|| kState.IsKeyDown(Keys.Right))
            {
                direction = Dir.Left;
                isMoving = true;
            }
            if (kState.IsKeyDown(Keys.W)|| kState.IsKeyDown(Keys.Up))
            {
                direction = Dir.Up;
                isMoving = true;
            }
            if (kState.IsKeyDown(Keys.S)|| kState.IsKeyDown(Keys.Down))
            {
                direction = Dir.Down;
                isMoving = true;
            }
            if (isMoving)
            {
                switch (direction)
                {
                    case Dir.Right:
                        position.X -= speed * dt;
                        break;
                    case Dir.Left:
                        position.X += speed * dt;
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
}
