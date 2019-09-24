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
        public Animate anim;
        public Animate[] ani = new Animate[4];
        private KeyboardState previous = Keyboard.GetState();
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
            switch(direction)
            {
                case Dir.Down:
                    anim = ani[0];
                    break;
                case Dir.Up:
                    anim = ani[1];
                    break;
                case Dir.Left:
                    anim = ani[2];
                    break;
                case Dir.Right:
                    anim = ani[3];
                    break;
                default:
                    break;

            }
            if (isMoving)
            {
                anim.Update(gameTime);
            }
            else
            {
                anim.setFrame(1);
            }
            isMoving = false;
            if (kState.IsKeyDown(Keys.A)|| kState.IsKeyDown(Keys.Left))
            {
                direction = Dir.Left;
                isMoving = true;
            }
            if (kState.IsKeyDown(Keys.D)|| kState.IsKeyDown(Keys.Right))
            {
                direction = Dir.Right;
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
            if (kState.IsKeyDown(Keys.Q))
            {
                
            }
            if (isMoving)
            {
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

           
            if (kState.IsKeyDown(Keys.D1)&&previous.IsKeyUp(Keys.D1))
            {
                Projectile.projectile1.Add(new Projectile(position, direction));
            }
            if (kState.IsKeyDown(Keys.N) && previous.IsKeyUp(Keys.N))
            {
                Projectile.projectile2.Add(new Projectile(position, direction));
            }
            if (kState.IsKeyDown(Keys.B) && previous.IsKeyUp(Keys.B))
            {
                Projectile.projectile3.Add(new Projectile(position, direction));
            }
            previous = kState;

            

           /* if(kState.IsKeyDown(keys.Space)){
                Projectile.projectiles.Add(new Porjectile(position, direction));
            }*/

        }
    }
}
