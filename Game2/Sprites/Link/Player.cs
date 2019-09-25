using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2.Sprites.Link
{
    class Player
    {
        private Vector2 position = new Vector2(960, 540);
        private int speed = 200;
        private Dir direction = Dir.Down;
        private bool isMoving = false;
        private bool isSwording = false;
        public Animate anim;
        public int radius=20;
        public Animate[] ani = new Animate[7];
        private KeyboardState previous = Keyboard.GetState();
        private ExitCommand exit;
        private Dictionary<Dir, Animate>facing = new Dictionary<Dir, Animate>();
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
        public Player(Game1 game)
        {
            exit = new ExitCommand(game);
            facing.Add(Dir.Down, LinkSpriteFactory.Instance.CreateMoveDown(1, 2));
            facing.Add(Dir.Up, LinkSpriteFactory.Instance.CreateMoveUp(1, 2));
            facing.Add(Dir.Left, LinkSpriteFactory.Instance.CreateMoveLeft(1, 2));
            facing.Add(Dir.Right, LinkSpriteFactory.Instance.CreateMoveRight(1, 2));
            facing.Add(Dir.DownSword, LinkSpriteFactory.Instance.CreateDownSword(1, 2));
            facing.Add(Dir.UpSword, LinkSpriteFactory.Instance.CreateUpSword(1, 2));
            facing.Add(Dir.LeftSword, LinkSpriteFactory.Instance.CreateLeftSword(1, 2));
            facing.Add(Dir.RightSword, LinkSpriteFactory.Instance.CreateRightSword(1, 2));
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState kState = Keyboard.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            anim = facing[direction];
            if (isMoving||isSwording)
            {
                anim.Update(gameTime);
            }
            else
            {
                anim.setFrame(1);
            }

            isMoving = false;
            isSwording = false;
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
            if (kState.IsKeyDown(Keys.Z)|| kState.IsKeyDown(Keys.N))
            {
                if (direction == Dir.Down)
                {
                    direction = Dir.DownSword;
                }
                if (direction == Dir.Up)
                {
                    direction = Dir.UpSword;
                }
                if (direction == Dir.Left)
                {
                    direction = Dir.LeftSword;
                }
                if (direction == Dir.Right)
                {
                    direction = Dir.RightSword;
                }

                isSwording = true;
                
                /*
                 * if(kState.IsKeyUp(Keys.Z)){
                   direction = Dir.Down;
                }*/

                isMoving = true;
                
            }
            if (kState.IsKeyDown(Keys.Q))
            {
                exit.Execute();
            }
            if (isMoving)
            {
                Vector2 tempPos = position;
                switch (direction)
                {
                    case Dir.Right:
                        tempPos.X += speed * dt;
                        if (!Blocks.Blocks.didCollide(tempPos, radius))
                        {
                            position.X += speed * dt;
                        }
                        //position.X += speed * dt;
                        break;
                    case Dir.Left:
                        tempPos.X -= speed * dt;
                        if (!Blocks.Blocks.didCollide(tempPos, radius))
                        {
                            position.X -= speed * dt;
                        }
                        //position.X -= speed * dt;
                        break;
                    case Dir.Up:
                        tempPos.Y -= speed * dt;
                        if (!Blocks.Blocks.didCollide(tempPos, radius))
                        {
                            position.Y -= speed * dt;
                        }
                        //position.Y -= speed * dt;
                        break;
                    case Dir.Down:
                        tempPos.Y += speed * dt;
                        if (!Blocks.Blocks.didCollide(tempPos, radius))
                        {
                            position.Y += speed * dt;
                        }
                        //position.Y += speed * dt;
                        break;
                    default:
                        break;
                }
            }
           
            if (kState.IsKeyDown(Keys.D1)&&previous.IsKeyUp(Keys.D1))
            {
                Projectile.bomb.Add(new Projectile(position, direction));
            }
            if (kState.IsKeyDown(Keys.D2) && previous.IsKeyUp(Keys.D2))
            {
                if (direction == Dir.Down)
                {
                    Projectile.arrowDown.Add(new Projectile(position, direction));
                }
                if (direction == Dir.Up)
                {
                    Projectile.arrowUp.Add(new Projectile(position, direction));
                }
                if (direction == Dir.Left)
                {
                    Projectile.arrowLeft.Add(new Projectile(position, direction));
                }
                if (direction == Dir.Right)
                {
                    Projectile.arrowRight.Add(new Projectile(position, direction));
                }
            }
            if (kState.IsKeyDown(Keys.B) && previous.IsKeyUp(Keys.B))
            {
                Projectile.bomb.Add(new Projectile(position, direction));
            }
            previous = kState;
                                                                
            

           /* if(kState.IsKeyDown(keys.Space)){
                Projectile.projectiles.Add(new Porjectile(position, direction));
            }*/

        }
    }

    public class StateMachine
    {
        private Dir direction = Dir.Down;
        private bool isMoving = false;
        public void LeftMove()
        {
            isMoving = true;
            direction = Dir.Left;
        }
        public void RightMove()
        {
            isMoving = true;
            direction = Dir.Right;
        }
        public void UpMove()
        {
            isMoving = true;
            direction = Dir.Up;
        }
        public void DownMove()
        {
            isMoving = true;
            direction = Dir.Down;
        }
        public void Update(GameTime gameTime)
        {

        }
    }
}
