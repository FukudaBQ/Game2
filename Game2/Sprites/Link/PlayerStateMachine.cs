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

    class PlayerStateMachine
    {
        private Dir direction = Dir.Down;
        private bool isMoving = false;
        private bool isSwording = false;
        private int speed = 200;
        public int radius = 20;
        Player player;
        private Vector2 position = new Vector2(960, 540);
        private KeyboardState previous = Keyboard.GetState();
        private Dictionary<Dir, Animate> facing = new Dictionary<Dir, Animate>();
        public Animate[] ani = new Animate[7];


        public void ChangeDirectionLeft()
        {
            direction = Dir.Left;
            isMoving = true;
        }
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public void SetFacing()
        {

        }

        public PlayerStateMachine(Player player)
        {
            
            facing.Add(Dir.Down, LinkSpriteFactory.Instance.CreateMoveDown(1, 2));
            facing.Add(Dir.Up, LinkSpriteFactory.Instance.CreateMoveUp(1, 2));
            facing.Add(Dir.Left, LinkSpriteFactory.Instance.CreateMoveLeft(1, 2));
            facing.Add(Dir.Right, LinkSpriteFactory.Instance.CreateMoveRight(1, 2));
            facing.Add(Dir.DownSword, LinkSpriteFactory.Instance.CreateDownSword(1, 2));
            facing.Add(Dir.UpSword, LinkSpriteFactory.Instance.CreateUpSword(1, 2));
            facing.Add(Dir.LeftSword, LinkSpriteFactory.Instance.CreateLeftSword(1, 2));
            facing.Add(Dir.RightSword, LinkSpriteFactory.Instance.CreateRightSword(1, 2));
            player.anim = facing[direction];
            this.player = player;

        }
        public void ChangeDirectionRight()
        {
            direction = Dir.Right;
            isMoving = true;
        }
        public void ChangeDirectionUp()
        {
            direction = Dir.Up;
            isMoving = true;
        }
        public void ChangeDirectionDown()
        {
            direction = Dir.Down;
            isMoving = true;
        }


        public void Update(GameTime gameTime)
        {
            KeyboardState kState = Keyboard.GetState();
            player.anim = facing[direction];
            if (isMoving || isSwording)
            {
                player.anim.Update(gameTime);
            }
            else
            {
                player.anim.setFrame(1);
            }
            isMoving = false;
            isSwording = false;
            if (kState.IsKeyDown(Keys.A) || kState.IsKeyDown(Keys.Left))
            {
                ChangeDirectionLeft();
            }
            if (kState.IsKeyDown(Keys.D) || kState.IsKeyDown(Keys.Right))
            {
                ChangeDirectionRight();
            }
            if (kState.IsKeyDown(Keys.W) || kState.IsKeyDown(Keys.Up))
            {
                ChangeDirectionUp();
            }
            if (kState.IsKeyDown(Keys.S) || kState.IsKeyDown(Keys.Down))
            {
                ChangeDirectionDown();
            }
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (kState.IsKeyDown(Keys.Z) || kState.IsKeyDown(Keys.N))
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

            if (isMoving)
            {
                Vector2 tempPos = player.position;
                switch (direction)
                {
                    case Dir.Right:
                        tempPos.X += speed * dt;
                        if (!Blocks.Blocks.didCollide(tempPos, radius))
                        {
                            player.position.X += speed * dt;
                        }
                        //position.X += speed * dt;
                        break;
                    case Dir.Left:
                        tempPos.X -= speed * dt;
                        if (!Blocks.Blocks.didCollide(tempPos, radius))
                        {
                            player.position.X -= speed * dt;
                        }
                        //position.X -= speed * dt;
                        break;
                    case Dir.Up:
                        tempPos.Y -= speed * dt;
                        if (!Blocks.Blocks.didCollide(tempPos, radius))
                        {
                            player.position.Y -= speed * dt;
                        }
                        //position.Y -= speed * dt;
                        break;
                    case Dir.Down:
                        tempPos.Y += speed * dt;
                        if (!Blocks.Blocks.didCollide(tempPos, radius))
                        {
                            player.position.Y += speed * dt;
                        }
                        //position.Y += speed * dt;
                        break;
                    default:
                        break;
                }
            }

            if (kState.IsKeyDown(Keys.D1) && previous.IsKeyUp(Keys.D1))
            {
                Projectile.bomb.Add(new Projectile(player.position, direction));
            }
            if (kState.IsKeyDown(Keys.D2) && previous.IsKeyUp(Keys.D2))
            {
                if (direction == Dir.Down)
                {
                    Projectile.arrowDown.Add(new Projectile(player.position, direction));
                }
                if (direction == Dir.Up)
                {
                    Projectile.arrowUp.Add(new Projectile(player.position, direction));
                }
                if (direction == Dir.Left)
                {
                    Projectile.arrowLeft.Add(new Projectile(player.position, direction));
                }
                if (direction == Dir.Right)
                {
                    Projectile.arrowRight.Add(new Projectile(player.position, direction));
                }
            }
            if (kState.IsKeyDown(Keys.D3) && previous.IsKeyUp(Keys.D3))
            {
                Projectile.boomerang.Add(new Projectile(player.position, direction));
            }
            previous = kState;
        }

    }
}
