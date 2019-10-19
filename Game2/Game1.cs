﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game2.Factory;
using Game2.Sprites.Link;
using Game2.Sprites.Blocks;
using Game2.Sprites.Enemies;
using Game2.Object.Items;
using System.Collections.Generic;
using Game2.Background;
using System.Xml;
using System;
using Game2.Collision;

using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using MonoGame.Extended;

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
        private Texture2D GeneralBlockSprite;
        
        private TiledMapRenderer mapRenderer;
        private TiledMap myMap;
        private Camera2D cam;
        private Vector2 camLocation;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 880;
            this.IsMouseVisible = true;

            
        }
        protected override void Initialize()
        {
            mapRenderer = new TiledMapRenderer(GraphicsDevice);
            cam = new Camera2D(GraphicsDevice);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            myMap = Content.Load<TiledMap>("map/mapD");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            ItemFactory.Instance.LoadAllTextures(Content);
            player = new Player(this);
            Register();
            /*TiledMapObject[] rupies = myMap.GetLayer<TiledMapObjectLayer>("fairy").Objects;
            foreach (var fa in rupies)
            {
                Item.items.Add(new Rupy2(new Vector2(fa.Position.X, fa.Position.Y + 800), spriteBatch));
            }*/
            TiledMapObject[] fairies = myMap.GetLayer<TiledMapObjectLayer>("fairy").Objects;
            foreach (var fa in fairies)
            {
                Item.items.Add(new Fairy2(new Vector2(fa.Position.X, fa.Position.Y + 800), spriteBatch));
            }
            TiledMapObject[] hearts = myMap.GetLayer<TiledMapObjectLayer>("heart").Objects;
            foreach (var ha in hearts)
            {
                Item.items.Add(new Heart(new Vector2(ha.Position.X, ha.Position.Y + 800), spriteBatch));
            }
            TiledMapObject[] clocks = myMap.GetLayer<TiledMapObjectLayer>("clock").Objects;
            foreach (var it in clocks)
            {
                Item.items.Add(new Clock2(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            Item.items.Add(new Key2(new Vector2(550, 150), spriteBatch));
            TiledMapObject[] keys = myMap.GetLayer<TiledMapObjectLayer>("key").Objects;
            foreach (var it in keys)
            {
                Item.items.Add(new Key2(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            Item.items.Add(new Compass2(new Vector2(640, 135), spriteBatch));
            TiledMapObject[] compasses = myMap.GetLayer<TiledMapObjectLayer>("compass").Objects;
            foreach (var it in compasses)
            {
                Item.items.Add(new Compass2(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            Item.items.Add(new Map2(new Vector2(730, 50), spriteBatch));
            TiledMapObject[] maps = myMap.GetLayer<TiledMapObjectLayer>("map").Objects;
            foreach (var it in maps)
            {
                Item.items.Add(new Map2(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            Item.items.Add(new Ring(new Vector2(1050, 60), spriteBatch));
            TiledMapObject[] rings = myMap.GetLayer<TiledMapObjectLayer>("ring").Objects;
            foreach (var it in rings)
            {
                Item.items.Add(new Ring(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            Item.items.Add(new MagicKey(new Vector2(1160, 130), spriteBatch));
            TiledMapObject[] magickeys = myMap.GetLayer<TiledMapObjectLayer>("magickey").Objects;
            foreach (var it in magickeys)
            {
                Item.items.Add(new MagicKey(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            Item.items.Add(new Ladder(new Vector2(180, 300), spriteBatch));
            Item.items.Add(new Raft(new Vector2(400, 300), spriteBatch));
            Blocks.blocks.Add(new GeneralBlock(new Vector2(480, 392)));
            Blocks.blocks.Add(new GeneralBlock(new Vector2(480, 589)));
            Blocks.blocks.Add(new GeneralBlock(new Vector2(1320, 392)));
            Blocks.blocks.Add(new GeneralBlock(new Vector2(1320, 589)));
            
            TiledMapObject[] blocks = myMap.GetLayer<TiledMapObjectLayer>("block").Objects;
            foreach (var blo in blocks)
            {
                Blocks.blocks.Add(new GeneralBlock(new Vector2(blo.Position.X, blo.Position.Y + 800)));
            }
            TiledMapObject[] waterblocks = myMap.GetLayer<TiledMapObjectLayer>("waterblock").Objects;
            foreach (var wblo in waterblocks)
            {
                Blocks.waterblocks.Add(new GeneralBlock(new Vector2(wblo.Position.X, wblo.Position.Y + 800)));
            }
            TiledMapObject[] upblocks = myMap.GetLayer<TiledMapObjectLayer>("upblock").Objects;
            TiledMapObject[] downblocks = myMap.GetLayer<TiledMapObjectLayer>("downblock").Objects;
            TiledMapObject[] leftblocks = myMap.GetLayer<TiledMapObjectLayer>("leftblock").Objects;
            TiledMapObject[] rightblocks = myMap.GetLayer<TiledMapObjectLayer>("rightblock").Objects;
            foreach (var blo in upblocks)
            {
                Blocks.upblocks.Add(new GeneralBlock(new Vector2(blo.Position.X, blo.Position.Y + 800)));
            }
            foreach (var blo in downblocks)
            {
                Blocks.downblocks.Add(new GeneralBlock(new Vector2(blo.Position.X, blo.Position.Y + 800)));
            }
            foreach (var blo in leftblocks)
            {
                Blocks.leftblocks.Add(new GeneralBlock(new Vector2(blo.Position.X, blo.Position.Y + 800)));
            }
            foreach (var blo in rightblocks)
            {
                Blocks.rightblocks.Add(new GeneralBlock(new Vector2(blo.Position.X, blo.Position.Y + 800)));
            }
            camLocation = new Vector2(3200, 3880);
        }

        private void Register()
        {
            bomb = Content.Load<Texture2D>("ZeldaSpriteBomb");
            arrowDown = Content.Load<Texture2D>("ArrowDown");
            arrowUp = Content.Load<Texture2D>("ArrowUp");
            arrowLeft = Content.Load<Texture2D>("ArrowLeft");
            arrowRight = Content.Load<Texture2D>("ArrowRight");
            boomerang = Content.Load<Texture2D>("boomerang");
            GeneralBlockSprite = Content.Load<Texture2D>("GeneralBlock");
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            player.Update(gameTime);

            foreach(Item it in Item.items)
            {
                it.Update(gameTime);
            }

            CollisionHandler collisionHandler = new CollisionHandler();

            collisionHandler.CollisionHandle(player);

            projHandler.Update(gameTime);
            cam.LookAt(player.camPosition);

            base.Update(gameTime);

        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            mapRenderer.Draw(myMap, cam.GetViewMatrix());
            spriteBatch.Begin(transformMatrix:cam.GetViewMatrix());

            foreach (Item it in Item.items)
            {
                it.Draw();
            }

            projHandler.Draw(spriteBatch, bomb, Projectile.bomb);
            projHandler.Draw(spriteBatch, arrowDown, Projectile.arrowDown);
            projHandler.Draw(spriteBatch, arrowUp, Projectile.arrowUp);
            projHandler.Draw(spriteBatch, arrowLeft, Projectile.arrowLeft);
            projHandler.Draw(spriteBatch, arrowRight, Projectile.arrowRight);
            projHandler.Draw(spriteBatch, boomerang, Projectile.boomerang);

            foreach (Blocks b in Blocks.blocks)
            {
                spriteBatch.Draw(GeneralBlockSprite, b.Position, Color.White);
            }


            player.anim.Draw(spriteBatch, player.Position);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
   
    
}
