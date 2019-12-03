using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Collision;
using Game2.Commands;
using Game2.Factory;
using Game2.Object.Items;
using Game2.Puzzle;
using Game2.Sprites.Link.Projectile;
using HUDManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game2.Sprites.Link
{
    public class Player
    {
      
        private bool victory = false;
        public Vector2 position = new Vector2(3140, 12800);
        public Vector2 camPosition = new Vector2(3200 ,12520);
        private Dir direction = Dir.Down;
        public Animate anim;
        private PlayerStateMachine stateMachine;
        private Dictionary<Dir, Animate> facing = new Dictionary<Dir, Animate>();
        private int radius=20;
        public int width = 10;
        public int length = 20;
        public Animate[] ani = new Animate[7];
        public Vector2[] MapBoundary = { new Vector2(3200, 3880), new Vector2(3200, 3000), new Vector2(3200, 2120),
            new Vector2(3200, 1240), new Vector2(1920, 1240), new Vector2(640, 1240), new Vector2(1920, 3000),
            new Vector2(640, 3000), new Vector2(4480, 3000), new Vector2(5760, 3000), new Vector2(5760, 2120),
            new Vector2(7040, 2120), new Vector2(1920, 3880), new Vector2(4480, 3880), new Vector2(3200, 4760),
            new Vector2(3200, 5640), new Vector2(4480, 5640), new Vector2(1920, 5640), };
        private KeyboardState previous = Keyboard.GetState();
        private ExitCommand exit;
        private ResetCommand reset;
        private CamMoveUp camMoveUp;
        private CamMoveDown camMoveDown;
        private CamMoveLeft camMoveLeft;
        private CamMoveRight camMoveRight;
        private int speed = 200;
        private Color pcolor = Color.White;
        private int damagedspeed = 600;
        private int health = 3;
        private float healthTimer = 0f;
        private float colorTimer = 0f;
        private int numOfKeys = 0;
        public int bombNum = 5;
        private HUD myHUD;
        private int tempSpeed = 200;
        private Sokoban mySokoban;



        public bool Victory
        {
            get { return victory; }
            set { victory = value; }
        }
        public int NumOfKeys
        {
            get { return numOfKeys; }
            set { numOfKeys = value; }
        }
        public float HealthTimer
        {
            get { return healthTimer; }
            set { healthTimer = value; }
        }
        public float ColorTimer
        {
            get { return colorTimer; }
            set { colorTimer = value; }
        }
        public Color Pcolor
        {
            get { return pcolor; }
            set { pcolor = value; }
        }

        public int Radius
        {
            get { return radius; }
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Damagedspeed
        {
            get { return damagedspeed; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int TempSpeed
        {
            get { return tempSpeed; }
            set { tempSpeed = value; }
        }


        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public void setX(float newX)
        {
            position.X = newX;
        }
        public void setY(float newY)
        {
            position.Y = newY;
        }
        public Vector2 getCamPosition()
        {
            return camPosition;
        }
        
        public Player(Game1 game)
        {
            exit = new ExitCommand(game);
            reset = new ResetCommand(this, game,myHUD);
            camMoveUp = new CamMoveUp(this);
            camMoveDown = new CamMoveDown(this);
            camMoveLeft = new CamMoveLeft(this);
            camMoveRight = new CamMoveRight(this);
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

        public void setSokoban(Sokoban sokoban)
        {
            mySokoban = sokoban;
        }

        public void setHUD(HUD myHUD)
        {
            this.myHUD = myHUD;
        }

        public void Update(GameTime gameTime)
        {
            
            if (Blocks.Blocks.inwater(position, length,width))
            {
                speed = 50;
            }else if(Blocks.Blocks.inbalck(position, length, width))
            {
                speed = 5;
            }
            else
            {
                speed = TempSpeed;
            }
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
            if (healthTimer > 0)
            {
                healthTimer -= dt;
                ColorTimer -= dt;
                
            }
            if (ColorTimer > 0)
            {
                ColorTimer -= dt;
            }
            if (stateMachine.ifIsMoving())
            {
                Vector2 tempPos = position;
                tempPos.X = position.X + 20;
                tempPos.Y = position.Y + 10;
                switch (direction)
                {
                    case Dir.Right:
                        tempPos.X += speed * dt;
                        if (!Blocks.Blocks.didCollide(tempPos, length,width)&&!Blocks.Rock.didCollide(tempPos, length, width)
                            && !Blocks.Door.didCollideLeft(tempPos, length, width) && !Blocks.Door.didCollideRight(tempPos, length, width)
                            && !Blocks.Door.didCollideDown(tempPos, length, width) && !mySokoban.DidCollide(tempPos, 0, 0)
                            && !Blocks.Door.didCollideUp(tempPos, length, width) && !Blocks.Door.didCollideLeft2(tempPos, length, width))
                        {
                            position.X += speed * dt;
                        }
                       
                        break;
                    case Dir.Left:
                        tempPos.X -= speed * dt;
                        if (!Blocks.Blocks.didCollide(tempPos, length, width) && !Blocks.Rock.didCollide(tempPos, length, width)
                            && !Blocks.Door.didCollideLeft(tempPos, length, width) && !Blocks.Door.didCollideRight(tempPos, length, width)
                            && !Blocks.Door.didCollideDown(tempPos, length, width) && !mySokoban.DidCollide(tempPos, 0, 0)
                            && !Blocks.Door.didCollideUp(tempPos, length, width) && !Blocks.Door.didCollideLeft2(tempPos, length, width))
                        {
                            position.X -= speed * dt;
                        }
                        
                        break;
                    case Dir.Up:
                        tempPos.Y -= speed * dt;
                        if (!Blocks.Blocks.didCollide(tempPos, length, width) && !Blocks.Rock.didCollide(tempPos, length, width)
                            && !Blocks.Door.didCollideLeft(tempPos, length, width) && !Blocks.Door.didCollideRight(tempPos, length, width)
                            && !Blocks.Door.didCollideDown(tempPos, length, width) && !mySokoban.DidCollide(tempPos, 0, 0)
                            && !Blocks.Door.didCollideUp(tempPos, length, width) && !Blocks.Door.didCollideLeft2(tempPos, length, width))
                        {
                            position.Y -= speed * dt;
                        }
                       
                        break;
                    case Dir.Down:
                        tempPos.Y += speed * dt;
                        if (!Blocks.Blocks.didCollide(tempPos, length, width) && !Blocks.Rock.didCollide(tempPos, length, width)
                            && !Blocks.Door.didCollideLeft(tempPos, length, width) && !Blocks.Door.didCollideRight(tempPos, length, width)
                            && !Blocks.Door.didCollideDown(tempPos, length, width) && !mySokoban.DidCollide(tempPos, 0, 0)
                            && !Blocks.Door.didCollideUp(tempPos, length, width) && !Blocks.Door.didCollideLeft2(tempPos, length, width))
                        {
                            position.Y += speed * dt;
                        }
                        
                        break;
                    default:
                        break;
                }
            }




            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.D1) && previous.IsKeyUp(Keys.D1))
            {
                if(bombNum > 0)
                {
                    bombNum--;
                    BombProj.bomb.Add(new BombProj(position));
                    myHUD.BombNumUpdate(bombNum);
                }
            }
            if (kState.IsKeyDown(Keys.D2) && previous.IsKeyUp(Keys.D2))
            {
                if (direction == Dir.Down)
                {
                    ArrowProj.arrowDown.Add(new ArrowProj(position, direction));
                }
                if (direction == Dir.Up)
                {
                    ArrowProj.arrowUp.Add(new ArrowProj(position, direction));
                }
                if (direction == Dir.Left)
                {
                    ArrowProj.arrowLeft.Add(new ArrowProj(position, direction));
                }
                if (direction == Dir.Right)
                {
                    ArrowProj.arrowRight.Add(new ArrowProj(position, direction));
                }
            }
            if (kState.IsKeyDown(Keys.D3) && previous.IsKeyUp(Keys.D3))
            {
                BoomerangProj.boomerang.Add(new BoomerangProj(position, direction));
            }
            if (kState.IsKeyDown(Keys.D4) && previous.IsKeyUp(Keys.D4))
            {
                if (Pokeball.pokeballSto.Count>0)
                {
                    Pokeball.pokeballProj.Add(new Pokeball(new Vector2(position.X+40f,position.Y+40f), direction));
                    Pokeball.pokeballSto.RemoveAll(p => p.Radius == 10);
                }
            }
            if (kState.IsKeyDown(Keys.D4) && previous.IsKeyUp(Keys.D4))
            {
                if (Pokeball.pokeballwithMonsterSto.Count > 0)
                {
                    Pokeball.pokeballwithMonsterProj.Add(new Pokeball(new Vector2(position.X + 40f, position.Y + 40f), direction));
                    Pokeball.pokeballwithMonsterSto.RemoveAll(p => p.Radius == 10);
                }
            }
            if (kState.IsKeyDown(Keys.D5) && previous.IsKeyUp(Keys.D5))
            {
                if (PortalGun.portalGunStoB.Count > 0)
                {
                    PortalGun.blueBs.Add(new PortalGun(new Vector2(position.X + 40f, position.Y + 40f), direction));
                    PortalGun.portalGunStoB.RemoveAll(p => p.Radius == 10);
                    MySounds.laser.Play();
                }
            }
            if (kState.IsKeyDown(Keys.D6) && previous.IsKeyUp(Keys.D6))
            {
                if (PortalGun.portalGunStoY.Count > 0)
                {
                    PortalGun.yellowBs.Add(new PortalGun(new Vector2(position.X + 40f, position.Y + 40f), direction));
                    PortalGun.portalGunStoY.RemoveAll(p => p.Radius == 10);
                    MySounds.laser.Play();
                }
            }

            previous = kState;
            if (kState.IsKeyDown(Keys.Q))
            {
                exit.Execute();
            }
            if (kState.IsKeyDown(Keys.P))
            {
                MediaPlayer.Pause();
            }
            if (kState.IsKeyDown(Keys.O))
            {
                MediaPlayer.Resume();
            }
            if (kState.IsKeyDown(Keys.R))
            {
                reset.Execute();
            }
            
            //TODO
            if (kState.IsKeyDown(Keys.Space))
            {
                mySokoban.Push(direction, position);
            }

        }
    }

 
}
