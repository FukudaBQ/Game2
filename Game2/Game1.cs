
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2.Factory;
using Microsoft.Xna.Framework.Content;
using Game2.Sprites.Link;
using Game2.Interfaces;
using Game2.Sprites.Blocks;
using Game2.Sprites.Enemies;
using Game2.Object.Items;
using Game2.Sprites.World;
using System.Collections.Generic;

namespace Game2
{
    enum Dir
    {
        Down,Up,Left,Right,DownSword,UpSword,LeftSword,RightSword
    }
    public class Game1 : Game
    {
        ProjectileHandler projHandler = new ProjectileHandler();
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Player player;
        private Texture2D bomb;
        private Texture2D arrowDown;
        private Texture2D arrowUp;
        private Texture2D arrowLeft;
        private Texture2D arrowRight;
        private Texture2D boomerang;
        private Texture2D handSprite;
        private Texture2D knightSprite;
        private Texture2D batSprite;
        private Texture2D monsterSprite;
        private Texture2D map1Sprite;
        private Texture2D GeneralBlockSprite;
        private Rupy rupy;
        private Triforce triforce;
        private Fairy fairy;
        private Dragon dragon;
        private Hand hand;
        private Monster monster;
        private Knight knight;
        private Bat bat;
        private OldMan oldMan;
        private Clock clock;
        private Key key;
        private Compass compass;
        private HeartContainer heartContainer;
        private Map map;
        private Bow bow;
        private Sword sword;
        private Arrow arrow;
        private Texture2D worldSprite;
        private Wolrd world;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            this.IsMouseVisible = true;

            
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            ItemFactory.Instance.LoadAllTextures(Content);
            player = new Player(this);
            Register();
            rupy = new Rupy(new Vector2(50,50), spriteBatch);
            triforce = new Triforce(new Vector2(100, 50), spriteBatch);
            fairy = new Fairy(new Vector2(200, 130), spriteBatch);
            bat = new Bat(batSprite, new Vector2(1200, 800), spriteBatch);
            knight = new Knight(knightSprite, new Vector2(1300, 800), spriteBatch);
            oldMan = new OldMan(new Vector2(270, 110), spriteBatch);
            heartContainer = new HeartContainer(new Vector2(370, 140),spriteBatch);
            clock = new Clock(new Vector2(460, 135), spriteBatch);
            key = new Key(new Vector2(550, 135), spriteBatch);
            compass= new Compass(new Vector2(640, 135), spriteBatch);
            map = new Map(new Vector2(730, 50), spriteBatch);
            bow = new Bow(new Vector2(820, 130), spriteBatch);
            sword = new Sword(new Vector2(910, 40), spriteBatch);
            arrow = new Arrow(new Vector2(955, 130), spriteBatch);
            Blocks.blocks.Add(new GeneralBlock(new Vector2(480, 392)));
            Blocks.blocks.Add(new GeneralBlock(new Vector2(480, 589)));
            Blocks.blocks.Add(new GeneralBlock(new Vector2(1320, 392)));
            Blocks.blocks.Add(new GeneralBlock(new Vector2(1320, 589)));
            //worldSprite = Content.Load<Texture2D>("World");
            //world = new Wolrd(worldSprite, new Vector2(0, 0), spriteBatch);
        }

        private void Register()
        {
            bomb = Content.Load<Texture2D>("ZeldaSpriteBomb");
            arrowDown = Content.Load<Texture2D>("ArrowDown");
            arrowUp = Content.Load<Texture2D>("ArrowUp");
            arrowLeft = Content.Load<Texture2D>("ArrowLeft");
            arrowRight = Content.Load<Texture2D>("ArrowRight");
            boomerang = Content.Load<Texture2D>("boomerang");
            Texture2D boss = Content.Load<Texture2D>("Boss");
            Texture2D dragon_sprite = Content.Load<Texture2D>("Dragon");
            handSprite = Content.Load<Texture2D>("hand");
            monsterSprite = Content.Load<Texture2D>("monster");
            batSprite = Content.Load<Texture2D>("bat");
            knightSprite = Content.Load<Texture2D>("knight");
            map1Sprite = Content.Load<Texture2D>("map1");
            GeneralBlockSprite = Content.Load<Texture2D>("GeneralBlock");
            dragon = new Dragon(dragon_sprite, new Vector2(800, 800), spriteBatch);
            hand = new Hand(handSprite, new Vector2(1000, 800), spriteBatch);
            monster = new Monster(monsterSprite, new Vector2(1100, 800), spriteBatch);
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            rupy.Update(gameTime);
            triforce.Update(gameTime);
            fairy.Update(gameTime);
            dragon.Update(gameTime);
            hand.Update(gameTime);
            knight.Update(gameTime);
            bat.Update(gameTime);
            monster.Update(gameTime);
            oldMan.Update(gameTime);


           
            projHandler.Update(gameTime);
            //world.Update(gameTime);

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            spriteBatch.Draw(map1Sprite, new Rectangle(0,0,1920,1080),Color.White);
            rupy.Draw();
            triforce.Draw();
            fairy.Draw();
            dragon.Draw();
            hand.Draw();
            bat.Draw();
            knight.Draw();
            monster.Draw();
            oldMan.Draw();
            heartContainer.Draw();
            clock.Draw();
            key.Draw();
            compass.Draw();
            map.Draw();
            bow.Draw();
            arrow.Draw();
            sword.Draw();

            projHandler.Draw(spriteBatch, bomb, Projectile.bomb);
            projHandler.Draw(spriteBatch, arrowDown, Projectile.arrowDown);
            projHandler.Draw(spriteBatch, arrowUp, Projectile.arrowUp);
            projHandler.Draw(spriteBatch, arrowLeft, Projectile.arrowLeft);
            projHandler.Draw(spriteBatch, arrowRight, Projectile.arrowRight);
            projHandler.Draw(spriteBatch, boomerang, Projectile.boomerang);

            /*foreach (Projectile i in Projectile.bomb)
            {
                spriteBatch.Draw(bomb, i.Position, Color.White);
            }*/

            /*foreach (Projectile i in Projectile.arrowDown)
            {
                spriteBatch.Draw(arrowDown, i.Position, Color.White);
            }
            foreach (Projectile i in Projectile.arrowUp)
            {
                spriteBatch.Draw(arrowUp, i.Position, Color.White);
            }
            foreach (Projectile i in Projectile.arrowLeft)
            {
                spriteBatch.Draw(arrowLeft, i.Position, Color.White);
            }
            foreach (Projectile i in Projectile.arrowRight)
            {
                spriteBatch.Draw(arrowRight, i.Position, Color.White);
            }
            foreach (Projectile i in Projectile.boomerang)
            {
                spriteBatch.Draw(boomerang, i.Position, Color.White);
            }*/
            foreach (Blocks b in Blocks.blocks)
            {
                spriteBatch.Draw(GeneralBlockSprite, b.Position, Color.White);
            }


            //world.Draw();
            spriteBatch.End();

            player.anim.Draw(spriteBatch, player.Position);

            base.Draw(gameTime);
        }
    }
}
