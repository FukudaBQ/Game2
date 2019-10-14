using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Commands;
using Game2.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2.Sprites.Link
{
    public class Player
    {
        
        public Vector2 position = new Vector2(960, 540);
        private Dir direction = Dir.Down;
        public Animate anim;
        private PlayerStateMachine stateMachine;
        private Dictionary<Dir, Animate> facing = new Dictionary<Dir, Animate>();
        public int radius=20;
        public Animate[] ani = new Animate[7];
        private KeyboardState previous = Keyboard.GetState();
        private ExitCommand exit;
        private ResetCommand reset;
        private int speed = 200;
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
            reset = new ResetCommand(this);
            stateMachine = new PlayerStateMachine(this);
            facing.Add(Dir.Down, LinkSpriteFactory.Instance.CreateMoveDown(1, 2));
            facing.Add(Dir.Up, LinkSpriteFactory.Instance.CreateMoveUp(1, 2));
            facing.Add(Dir.Left, LinkSpriteFactory.Instance.CreateMoveLeft(1, 2));
            facing.Add(Dir.Right, LinkSpriteFactory.Instance.CreateMoveRight(1, 2));
            facing.Add(Dir.DownSword, LinkSpriteFactory.Instance.CreateDownSword(1, 2));
            facing.Add(Dir.UpSword, LinkSpriteFactory.Instance.CreateUpSword(1, 2));
            facing.Add(Dir.LeftSword, LinkSpriteFactory.Instance.CreateLeftSword(1, 2));
            facing.Add(Dir.RightSword, LinkSpriteFactory.Instance.CreateRightSword(1, 2));
            anim = facing[direction];

        }


        public void Update(GameTime gameTime)
        {
            
            stateMachine.Update(gameTime);
            direction = stateMachine.getDirection();
            anim = facing[direction];
            if (stateMachine.ifIsMoving() || stateMachine.ifIsSwording())
            {
                anim.Update(gameTime);
            }
            else
            {
                anim.setFrame(1);
            }
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (stateMachine.ifIsMoving())
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




            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.D1) && previous.IsKeyUp(Keys.D1))
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
            if (kState.IsKeyDown(Keys.D3) && previous.IsKeyUp(Keys.D3))
            {
                Projectile.boomerang.Add(new Projectile(position, direction));
            }
            previous = kState;
            if (kState.IsKeyDown(Keys.Q))
            {
                exit.Execute();
            }
            if (kState.IsKeyDown(Keys.R))
            {
                reset.Execute();
            }


        }
    }

 
}
