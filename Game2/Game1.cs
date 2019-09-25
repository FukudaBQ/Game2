
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2.Factory;
using Game2.Object;
using Microsoft.Xna.Framework.Content;
using Game2.Sprites.Link;
using Game2.Interfaces;
using Game2.Sprites.Items;
using Game2.Sprites.Blocks;
using Game2.Sprites.Enemies;

namespace Game2
{
    enum Dir
    {
        Down,Up,Left,Right,DownSword,UpSword,LeftSword,RightSword
    }
    
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Player player;
        Texture2D playerSprite;
        Texture2D moveDown;
        Texture2D moveUp;
        Texture2D moveLeft;
        Texture2D moveRight;
        //private ArrowSprite arrow;
        Texture2D bomb;
        Texture2D arrowDown;
        Texture2D arrowUp;
        Texture2D arrowLeft;
        Texture2D arrowRight;
        Texture2D boomerang;
        Texture2D map1Sprite;
        Texture2D GeneralBlockSprite;
        Rupy rupy;
        Triforce triforce;
        Fairy fairy;
        Dragon dragon;
        OldMan oldMan;
        Clock clock;
        Key key;
        HeartContainer heartContainer;
        //Link player;
        //private static ContentManager myContent;
        //Zijie Wei
        //Bowei QU
        //Hangyu Ying 
        //Yong Zhang
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            this.IsMouseVisible = true;

            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            ItemFactory.Instance.LoadAllTextures(Content);
            //player = new Link(spriteBatch);
            // TODO: use this.Content to load your game content here
            playerSprite = Content.Load<Texture2D>("Link");/*
            moveDown = Content.Load<Texture2D>("LinkFaceFront");
            moveUp = Content.Load<Texture2D>("LinkBackWalking");
            moveLeft = Content.Load<Texture2D>("LinkLeftWalking");
            moveRight = Content.Load<Texture2D>("LinkRightWalking");
            downSword = Content.Load<Texture2D>("StandSwordDown");*/
            player = new Player(this);
            bomb = Content.Load<Texture2D>("ZeldaSpriteBomb");
            arrowDown = Content.Load<Texture2D>("ArrowDown");
            arrowUp = Content.Load<Texture2D>("ArrowUp");
            arrowLeft = Content.Load<Texture2D>("ArrowLeft");
            arrowRight = Content.Load<Texture2D>("ArrowRight");
            boomerang= Content.Load<Texture2D>("boomerang");
            Texture2D boss = Content.Load<Texture2D>("Boss");
            Texture2D item = Content.Load<Texture2D>("Item");
            Texture2D NPC = Content.Load<Texture2D>("NPC");
            map1Sprite = Content.Load<Texture2D>("map1");
            GeneralBlockSprite = Content.Load<Texture2D>("GeneralBlock");

            rupy = new Rupy(new Vector2(50,50), spriteBatch);
            triforce = new Triforce(new Vector2(100, 50), spriteBatch);
            fairy = new Fairy(new Vector2(200, 130), spriteBatch);
            dragon = new Dragon(boss, new Vector2(800, 800), spriteBatch);
            oldMan = new OldMan(NPC, new Vector2(270, 110), spriteBatch);
            heartContainer = new HeartContainer(item, new Vector2(370, 130),spriteBatch);
            clock = new Clock(item, new Vector2(460, 135), spriteBatch);
            key = new Key(item, new Vector2(550, 135), spriteBatch);
            Blocks.blocks.Add(new GeneralBlock(new Vector2(480, 392)));
            Blocks.blocks.Add(new GeneralBlock(new Vector2(480, 589)));
            Blocks.blocks.Add(new GeneralBlock(new Vector2(1320, 392)));
            Blocks.blocks.Add(new GeneralBlock(new Vector2(1320, 589)));

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);
            rupy.Update(gameTime);
            triforce.Update(gameTime);
            fairy.Update(gameTime);
            dragon.Update(gameTime);
            oldMan.Update(gameTime);
            

            foreach(Projectile proj in Projectile.bomb){
                proj.Update(gameTime);
            }
            foreach (Projectile proj in Projectile.arrowDown)
            {
                proj.Update(gameTime);
            }
            foreach (Projectile proj in Projectile.arrowUp)
            {
                proj.Update(gameTime);
            }
            foreach (Projectile proj in Projectile.arrowLeft)
            {
                proj.Update(gameTime);
            }
            foreach (Projectile proj in Projectile.arrowRight)
            {
                proj.Update(gameTime);
            }
            foreach (Projectile proj in Projectile.boomerang)
            {
                proj.Update(gameTime);
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here
            
            spriteBatch.Begin();
            spriteBatch.Draw(map1Sprite, new Rectangle(0,0,1920,1080),Color.White);
            rupy.Draw();
            triforce.Draw();
            fairy.Draw();
            dragon.Draw();
            oldMan.Draw();
            heartContainer.Draw();
            clock.Draw();
            key.Draw();
            foreach (Projectile i in Projectile.bomb)
            {
                spriteBatch.Draw(bomb, i.Position, Color.White);
            }
            foreach (Projectile i in Projectile.arrowDown)
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
            }
            foreach (Blocks b in Blocks.blocks)
            {
                spriteBatch.Draw(GeneralBlockSprite, b.Position, Color.White);
            }
            //spriteBatch.Draw(bomb,new Rectangle(0,0,15,25));
            
            /*foreach(Projectile proj in Projectile.projectile1){
                SpriteBatch.Draw(bomb,proj.Position,Color.Wihte);
            }*/

            spriteBatch.End();
            
                player.anim.Draw(spriteBatch, player.Position);
            

            base.Draw(gameTime);
        }
    }
}
