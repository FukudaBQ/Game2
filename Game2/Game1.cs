
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2.Factory;
using Game2.Object;
using Microsoft.Xna.Framework.Content;
using Game2.Sprites.Link;
using Game2.Interfaces;
using Game2.Sprites.Items;

namespace Game2
{
    enum Dir
    {
        Down,Up,Left,Right
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
        Texture2D dragon;
        //private ArrowSprite arrow;
        Texture2D bomb;
        Texture2D LinkUsingSword;
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
            player = new Player(this);
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //LinkSpriteFactory.Instance.LoadAllTextures(Content);
            //player = new Link(spriteBatch);
            // TODO: use this.Content to load your game content here
            playerSprite = Content.Load<Texture2D>("Link");
            moveDown = Content.Load<Texture2D>("LinkFaceFront");
            moveUp = Content.Load<Texture2D>("LinkBackWalking");
            moveLeft = Content.Load<Texture2D>("LinkLeftWalking");
            moveRight = Content.Load<Texture2D>("LinkRightWalking");
            bomb = Content.Load<Texture2D>("ZeldaSpriteBomb");
            LinkUsingSword = Content.Load<Texture2D>("LinkUsingSword");
            player.ani[0] = new Animate(moveDown, 1, 2);
            player.ani[1] = new Animate(moveUp, 1, 2);
            player.ani[2] = new Animate(moveLeft, 1, 2);
            player.ani[3] = new Animate(moveRight, 1, 2);
            Texture2D boss = Content.Load<Texture2D>("Boss");
            Texture2D item = Content.Load<Texture2D>("Item");

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
            /*
             * foreach(Projectile i in Projectile.projectile1)
            {
                i.Update(gameTime);
            }
            foreach (Projectile i in Projectile.projectile2)
            {
                i.Update(gameTime);
            }
            foreach (Projectile i in Projectile.projectile3)
            {
                i.Update(gameTime);
            }*/
            foreach(Projectile proj in Projectile.bomb){
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
            player.anim.Draw(spriteBatch, player.Position);
            spriteBatch.Begin();
            foreach (Projectile i in Projectile.bomb)
            {
                spriteBatch.Draw(bomb, i.Position, Color.White);
            }
            foreach (Projectile i in Projectile.arrow)
            {
                spriteBatch.Draw(LinkUsingSword, i.Position, Color.White);
            }
            foreach (Projectile i in Projectile.boomerang)
            {
                spriteBatch.Draw(moveLeft, i.Position, Color.White);
            }
            //spriteBatch.Draw(bomb,new Rectangle(0,0,15,25));
            
            /*foreach(Projectile proj in Projectile.projectile1){
                SpriteBatch.Draw(bomb,proj.Position,Color.Wihte);
            }*/

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
