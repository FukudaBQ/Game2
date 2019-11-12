
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game2.Factory;
using Game2.Sprites.Link;
using Game2.Sprites.Blocks;
using Game2.Sprites.Enemies;
using Game2.Object.Items;
using System.Collections.Generic;
using System.Xml;
using System;
using Game2.Collision;

using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Game2.Sprites.Link.Projectile;
//using Game2.Object.Enemies;

namespace Game2
{
    enum Dir
    {
        Down,Up,Left,Right,DownSword,UpSword,LeftSword,RightSword
    }

    public static class MySounds
    {
        public static SoundEffect attack;
        public static Song overworld;
    }
    public class Game1 : Game
    {
        private SpriteFont numOfKeysFont;
        
        private Texture2D deadLinkSprite;
        private Animate deadLinkSpin;
        BombHandler bombHandler = new BombHandler();
        ArrowHandler arrowHandler = new ArrowHandler();
        BoomerangHandler boomerangHandler = new BoomerangHandler();
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Player player;
        private PlayerDying playerDying;
        private Texture2D bomb;
        private Texture2D arrowDown;
        private Texture2D arrowUp;
        private Texture2D arrowLeft;
        private Texture2D arrowRight;
        private Texture2D boomerang;
        private Texture2D handSprite;
        private Texture2D knightSprite;
        private Texture2D batSprite;
        private Texture2D explosionSprite;
        private Texture2D monsterSprite;
        private Texture2D GeneralBlockSprite;
        private Texture2D fireballSprite;
        private Texture2D dragonSprite;
        private Texture2D HUD;
        private Texture2D HUDMap;
        private Texture2D veryGreen;
        private Texture2D rockSprite;

        private Bat bat;
        private Dragon dragon;
        private Key2 key;
        private Monster monster;
        private Hand hand;
        private Knight knight;
        private TiledMapRenderer mapRenderer;
        private TiledMap myMap;
        private Camera2D cam;
        private Vector2 camLocation;

        private HUD myHUD;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 1160;
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
            numOfKeysFont = Content.Load<SpriteFont>("numOfKeys");
            myMap = Content.Load<TiledMap>("map/mapD");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            ItemFactory.Instance.LoadAllTextures(Content);
            player = new Player(this);
            Register();

            myHUD = new HUD(player, HUD, spriteBatch, HUDMap, veryGreen);

            bat = new Bat(batSprite, new Vector2(2000, 1240), spriteBatch);
            dragon = new Dragon(dragonSprite, new Vector2(500, 3000), spriteBatch);
            key = new Key2( new Vector2(400, 2700), spriteBatch);
            monster = new Monster(monsterSprite, new Vector2(1500, 1000), spriteBatch);
            hand = new Hand(handSprite, new Vector2(1500, 3000), spriteBatch);
            knight = new Knight(knightSprite, new Vector2(5500, 1900), spriteBatch);
            //aa
            deadLinkSprite = Content.Load<Texture2D>("LinkStand4Directions");
            deadLinkSpin = new Animate(deadLinkSprite, 1, 4);

            TiledMapObject[] bats = myMap.GetLayer<TiledMapObjectLayer>("bat").Objects;
            foreach (var bat in bats)
            {
                Bat.bats.Add(new Bat(batSprite, new Vector2(bat.Position.X, bat.Position.Y + 840), spriteBatch));
                
            }

            TiledMapObject[] dragons = myMap.GetLayer<TiledMapObjectLayer>("dragon").Objects;
            foreach (var dra in dragons)
            {
                Dragon.dragons.Add(new Dragon(dragonSprite, new Vector2(dra.Position.X, dra.Position.Y + 840), spriteBatch));

            }

            TiledMapObject[] knights = myMap.GetLayer<TiledMapObjectLayer>("knight").Objects;
            foreach (var kn in knights)
            {
                Knight.knights.Add(new Knight(knightSprite, new Vector2(kn.Position.X, kn.Position.Y + 840), spriteBatch));

            }

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
            TiledMapObject[] keys = myMap.GetLayer<TiledMapObjectLayer>("key").Objects;
            foreach (var it in keys)
            {
                Item.items.Add(new Key2(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            TiledMapObject[] compasses = myMap.GetLayer<TiledMapObjectLayer>("compass").Objects;
            foreach (var it in compasses)
            {
                Item.items.Add(new Compass2(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            TiledMapObject[] maps = myMap.GetLayer<TiledMapObjectLayer>("map").Objects;
            foreach (var it in maps)
            {
                Item.items.Add(new Map2(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            TiledMapObject[] rings = myMap.GetLayer<TiledMapObjectLayer>("ring").Objects;
            foreach (var it in rings)
            {
                Item.items.Add(new Ring(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            TiledMapObject[] magickeys = myMap.GetLayer<TiledMapObjectLayer>("magickey").Objects;
            foreach (var it in magickeys)
            {
                Item.items.Add(new MagicKey(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            TiledMapObject[] ladder = myMap.GetLayer<TiledMapObjectLayer>("ladder").Objects;
            foreach (var it in ladder)
            {
                Item.items.Add(new Ladder(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            TiledMapObject[] raft = myMap.GetLayer<TiledMapObjectLayer>("raft").Objects;
            foreach (var it in raft)
            {
                Item.items.Add(new Raft(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            TiledMapObject[] bomb = myMap.GetLayer<TiledMapObjectLayer>("bomb").Objects;
            foreach (var it in bomb)
            {
                Item.items.Add(new Bomb(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            TiledMapObject[] boomerang = myMap.GetLayer<TiledMapObjectLayer>("boomerang").Objects;
            foreach (var it in boomerang)
            {
                Item.items.Add(new Boomerang(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            TiledMapObject[] bow = myMap.GetLayer<TiledMapObjectLayer>("bow").Objects;
            foreach (var it in bow)
            {
                Item.items.Add(new Bow2(new Vector2(it.Position.X, it.Position.Y + 800), spriteBatch));
            }
            TiledMapObject[] blocks = myMap.GetLayer<TiledMapObjectLayer>("block").Objects;
            foreach (var blo in blocks)
            {
                Blocks.blocks.Add(new GeneralBlock(new Vector2(blo.Position.X, blo.Position.Y + 840)));
            }
            TiledMapObject[] rocks = myMap.GetLayer<TiledMapObjectLayer>("rock").Objects;
            foreach (var r in rocks)
            {
                Rock.rocks.Add(new RockBlock(new Vector2(r.Position.X, r.Position.Y + 840)));
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
            batSprite = Content.Load<Texture2D>("bat");
            explosionSprite= Content.Load<Texture2D>("explosion1");
            dragonSprite = Content.Load<Texture2D>("Dragon");
            fireballSprite = Content.Load<Texture2D>("fireball");
            monsterSprite =Content.Load<Texture2D>("monster");
            handSprite = Content.Load<Texture2D>("hand");
            knightSprite = Content.Load<Texture2D>("knight");
            MySounds.attack = Content.Load<SoundEffect>("music/UseSword");
            MySounds.overworld = Content.Load<Song>("music/Dungeon");
            MediaPlayer.Play(MySounds.overworld);
            HUD = Content.Load<Texture2D>("HUD");
            HUDMap = Content.Load<Texture2D>("small_map");
            veryGreen = Content.Load<Texture2D>("Green");
            rockSprite = Content.Load<Texture2D>("rock");
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            deadLinkSpin.Update(gameTime);
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (player.Health > 0)
            {
                player.Update(gameTime);
            }
            else
            {
                //playerDying.Update(gameTime);
            }
            //bat.Update(gameTime,player.Position);
            dragon.Update(gameTime);
            monster.Update(gameTime);
            hand.Update(gameTime);
            knight.Update(gameTime);

            foreach (Item it in Item.items)
            {
                it.Update(gameTime);
            }
            foreach (explosion ex in explosion.exp)
            {
                ex.Update(gameTime);
            }
            foreach (Knight kn in Knight.knights)
            {
                kn.Update(gameTime);
                int sum = player.Radius + kn.Radius;
                if (Vector2.Distance(player.Position, kn.Location) < sum && player.HealthTimer <= 0)
                {

                    player.Health--;
                    Vector2 moveDir = player.Position - kn.Location;
                    moveDir.Normalize();

                    player.Pcolor = Color.Red;
                    Vector2 temp = player.Position + moveDir * player.Damagedspeed * dt * 15;
                    if (!Blocks.didCollide(temp, player.length, player.width))
                    {
                        player.Position += moveDir * player.Damagedspeed * dt * 15;
                    }

                    player.HealthTimer = 1.0f;
                }
                if (player.HealthTimer <= 0)
                {
                    player.Pcolor = Color.White;
                }

            }
            foreach (Dragon dra in Dragon.dragons)
            {
                dra.Update(gameTime);
                if (dragon.Timer <= 0)
                {
                    fireball.fireDown.Add(new fireball(dra.Location, Dir.Down));
                    fireball.fireUp.Add(new fireball(dra.Location, Dir.Up));
                    fireball.fireLeft.Add(new fireball(dra.Location, Dir.Left));
                    dragon.Timer = 2;
                }
                int sum = player.Radius + dra.Radius;
                if (Vector2.Distance(player.Position, dra.Location) < sum && player.HealthTimer <= 0)
                {

                    player.Health--;
                    Vector2 moveDir = player.Position - dra.Location;
                    moveDir.Normalize();

                    player.Pcolor = Color.Red;
                    Vector2 temp = player.Position + moveDir * player.Damagedspeed * dt * 15;
                    if (!Blocks.didCollide(temp, player.length, player.width))
                    {
                        player.Position += moveDir * player.Damagedspeed * dt * 15;
                    }

                    player.HealthTimer = 1.0f;
                }
                if (player.HealthTimer <= 0)
                {
                    player.Pcolor = Color.White;
                }
            }
            foreach (Bat bat in Bat.bats)
            {
                bat.Update(gameTime, player.position);
                int sum = player.Radius + bat.Radius;
                if (Vector2.Distance(player.Position, bat.location) < sum&&player.HealthTimer<=0)
                {
                    
                    player.Health--;
                    Vector2 moveDir =player.Position - bat.location;
                    moveDir.Normalize();
                    
                        player.Pcolor = Color.Red;
                    Vector2 temp = player.Position + moveDir * player.Damagedspeed * dt * 15;
                    if (!Blocks.didCollide(temp, player.length, player.width))
                    {
                        player.Position += moveDir * player.Damagedspeed * dt * 15;
                    }

                    player.HealthTimer = 1.0f;
                }
                if(player.HealthTimer <= 0)
                {
                    player.Pcolor = Color.White;
                }
            }
            foreach (BombProj b in BombProj.bomb)
            {
                foreach (Bat bat in Bat.bats)
                {
                    int sum = b.Radius + bat.Radius;
                    if (Vector2.Distance(b.Position, bat.location) < sum)
                    {
                        b.Collided = true;
                        bat.Health--;
                        if (bat.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bat.location));
                        }
                    }
                }
                foreach (Dragon dra in Dragon.dragons)
                {
                    int sum = b.Radius + dra.Radius;
                    if (Vector2.Distance(b.Position, dra.Location) < sum)
                    {
                        b.Collided = true;
                        dra.Health--;
                        if (dra.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(dra.Location));
                        }
                    }
                }
            }
            foreach (ArrowProj arrow in ArrowProj.arrowLeft)
            {
                if (Blocks.didCollide(arrow.Position, 10, 10))
                {
                    arrow.Collided = true;
                }
                foreach (Bat bat in Bat.bats)
                {
                    int sum = arrow.Radius + bat.Radius;
                    if (Vector2.Distance(arrow.Position, bat.location) < sum)
                    {
                        arrow.Collided = true;
                        bat.Health--;
                        if (bat.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bat.location));
                        }
                    }
                    
                }
                foreach (Dragon dra in Dragon.dragons)
                {
                    int sum = arrow.Radius + dra.Radius;
                    if (Vector2.Distance(arrow.Position, dra.Location) < sum)
                    {
                        arrow.Collided = true;
                        dra.Health--;
                        if (dra.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(dra.Location));
                        }
                    }

                }
            }
            foreach (ArrowProj arrow in ArrowProj.arrowRight)
            {
                if (Blocks.didCollide(arrow.Position, 10, 10))
                {
                    arrow.Collided = true;
                }
                foreach (Bat bat in Bat.bats)
                {
                    int sum = arrow.Radius + bat.Radius;
                    if (Vector2.Distance(arrow.Position, bat.location) < sum)
                    {
                        arrow.Collided = true;
                        bat.Health--;
                        if (bat.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bat.location));
                        }
                    }
                }
                foreach (Dragon dra in Dragon.dragons)
                {
                    int sum = arrow.Radius + dra.Radius;
                    if (Vector2.Distance(arrow.Position, dra.Location) < sum && dra.HealthTimer <= 0)
                    {
                        arrow.Collided = true;
                        dra.Health--;
                        dra.Dcolor = Color.Red;
                        if (dra.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(dra.Location));
                        }
                        dra.HealthTimer = 1.0f;
                    }
                    if (dra.HealthTimer <= 0)
                    {
                        dra.Dcolor = Color.White;
                    }
                }
            }
            foreach (ArrowProj arrow in ArrowProj.arrowUp)
            {
                if (Blocks.didCollide(arrow.Position, 10, 10))
                {
                    arrow.Collided = true;
                }
                foreach (Bat bat in Bat.bats)
                {
                    int sum = arrow.Radius + bat.Radius;
                    if (Vector2.Distance(arrow.Position, bat.location) < sum)
                    {
                        arrow.Collided = true;
                        bat.Health--;
                        if (bat.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bat.location));
                        }
                    }
                }
                foreach (Dragon dra in Dragon.dragons)
                {
                    int sum = arrow.Radius + dra.Radius;
                    if (Vector2.Distance(arrow.Position, dra.Location) < sum && dra.HealthTimer <= 0)
                    {
                        arrow.Collided = true;
                        dra.Health--;
                        dra.Dcolor = Color.Red;
                        if (dra.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(dra.Location));
                        }
                        dra.HealthTimer = 1.0f;
                    }
                    if (dra.HealthTimer <= 0)
                    {
                        dra.Dcolor = Color.White;
                    }
                }
            }
            foreach (ArrowProj arrow in ArrowProj.arrowDown)
            {
                if (Blocks.didCollide(arrow.Position, 10, 10))
                {
                    arrow.Collided = true;
                }
                foreach (Bat bat in Bat.bats)
                {
                    int sum = arrow.Radius + bat.Radius;
                    if (Vector2.Distance(arrow.Position, bat.location) < sum)
                    {
                        arrow.Collided = true;
                        bat.Health--;
                        if (bat.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bat.location));
                        }
                    }
                }
                foreach (Dragon dra in Dragon.dragons)
                {
                    int sum = arrow.Radius + dra.Radius;
                    if (Vector2.Distance(arrow.Position, dra.Location) < sum && dra.HealthTimer <= 0)
                    {
                        arrow.Collided = true;
                        dra.Health--;
                        dra.Dcolor = Color.Red;
                        if (dra.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(dra.Location));
                        }
                        dra.HealthTimer = 1.0f;
                    }
                    if (dra.HealthTimer <= 0)
                    {
                        dra.Dcolor = Color.White;
                    }
                }
            }
            foreach (fireball fir in fireball.fireDown)
            {
                if (Blocks.didCollide(fir.Position, 5, 5))
                {
                    fir.Collided = true;
                }
                fir.Update(gameTime);
                int sum = player.Radius + fir.Radius;
                if (Vector2.Distance(player.Position, fir.Position) < sum && player.HealthTimer <= 0)
                {
                    fir.Collided = true;
                    player.Health--;
                    Vector2 moveDir = player.Position - fir.Position;
                    moveDir.Normalize();

                    player.Pcolor = Color.Red;
                    Vector2 temp = player.Position + moveDir * player.Damagedspeed * dt * 15;
                    if (!Blocks.didCollide(temp, player.length, player.width))
                    {
                        player.Position += moveDir * player.Damagedspeed * dt * 15;
                    }

                    player.HealthTimer = 1.0f;
                }
                if (player.HealthTimer <= 0)
                {
                    player.Pcolor = Color.White;
                }

            }
            foreach (fireball fir in fireball.fireUp)
            {
                if (Blocks.didCollide(fir.Position, 5, 5))
                {
                    fir.Collided = true;
                }
                fir.Update(gameTime);
                int sum = player.Radius + fir.Radius;
                if (Vector2.Distance(player.Position, fir.Position) < sum && player.HealthTimer <= 0)
                {
                    fir.Collided = true;
                    player.Health--;
                    Vector2 moveDir = player.Position - fir.Position;
                    moveDir.Normalize();

                    player.Pcolor = Color.Red;
                    Vector2 temp = player.Position + moveDir * player.Damagedspeed * dt * 15;
                    if (!Blocks.didCollide(temp, player.length, player.width))
                    {
                        player.Position += moveDir * player.Damagedspeed * dt * 15;
                    }

                    player.HealthTimer = 1.0f;
                }
                if (player.HealthTimer <= 0)
                {
                    player.Pcolor = Color.White;
                }
            }
            foreach (fireball fir in fireball.fireLeft)
            {
                if (Blocks.didCollide(fir.Position, 5, 5))
                {
                    fir.Collided = true;
                }
                fir.Update(gameTime);
                int sum = player.Radius + fir.Radius;
                if (Vector2.Distance(player.Position, fir.Position) < sum && player.HealthTimer <= 0)
                {
                    fir.Collided = true;
                    player.Health--;
                    Vector2 moveDir = player.Position - fir.Position;
                    moveDir.Normalize();

                    player.Pcolor = Color.Red;
                    Vector2 temp = player.Position + moveDir * player.Damagedspeed * dt * 15;
                    if (!Blocks.didCollide(temp, player.length, player.width))
                    {
                        player.Position += moveDir * player.Damagedspeed * dt * 15;
                    }

                    player.HealthTimer = 1.0f;
                }
                if (player.HealthTimer <= 0)
                {
                    player.Pcolor = Color.White;
                }
            }

            ArrowProj.arrowLeft.RemoveAll(p=>p.Collided==true);
            ArrowProj.arrowRight.RemoveAll(p => p.Collided == true);
            ArrowProj.arrowUp.RemoveAll(p => p.Collided == true);
            ArrowProj.arrowDown.RemoveAll(p => p.Collided == true);
            Bat.bats.RemoveAll(e => e.Health<=0);
            Dragon.dragons.RemoveAll(d => d.Health <= 0);
            explosion.exp.RemoveAll(ex => ex.Timer <= 0);
            fireball.fireDown.RemoveAll(f => f.Collided == true);
            fireball.fireUp.RemoveAll(f => f.Collided == true);
            fireball.fireLeft.RemoveAll(f => f.Collided == true);
            CollisionHandler collisionHandler = new CollisionHandler();

            collisionHandler.CollisionHandle(player, myHUD);

            bombHandler.Update(gameTime);
            arrowHandler.Update(gameTime);
            boomerangHandler.Update(gameTime);
            cam.LookAt(player.camPosition);
            //cam.LookAt(player.position);

            base.Update(gameTime);

        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            
            mapRenderer.Draw(myMap, cam.GetViewMatrix());
            spriteBatch.Begin(transformMatrix:cam.GetViewMatrix());
            foreach (explosion ex in explosion.exp)
            {
                spriteBatch.Draw(explosionSprite, ex.Position, Color.White);
            }
            //foreach (Enemies en in Enemies.enemies)
            //{
            //Texture2D spritetoDraw;
            //if (en.GetType() == typeof(Bats))
            //{
            //spritetoDraw = batSprite;
            //}
            //else
            //{
            //spritetoDraw = knightSprite;
            //}
            //spriteBatch.Draw(spritetoDraw, en.Position, Color.White);
            //}

            myHUD.Draw();


            foreach (Bat bat in Bat.bats)
            {
                bat.Draw(bat.location);
            }
            foreach (Dragon dra in Dragon.dragons)
            {
                dra.Draw(dra.Location);
            }

            foreach (Knight kn in Knight.knights)
            {
                kn.Draw();
            }
            foreach(Rock r in Rock.rocks)
            {
                spriteBatch.Draw(rockSprite, r.Position, Color.White);
            }

            foreach (Item it in Item.items)
            {
                it.Draw();
            }

            foreach (fireball fir in fireball.fireDown)
            {
                spriteBatch.Draw(fireballSprite, fir.Position, Color.White);
            }
            foreach (fireball fir in fireball.fireUp)
            {
                spriteBatch.Draw(fireballSprite, fir.Position, Color.White);
            }
            foreach (fireball fir in fireball.fireLeft)
            {
                spriteBatch.Draw(fireballSprite, fir.Position, Color.White);
            }

            bombHandler.Draw(spriteBatch, bomb, BombProj.bomb,explosionSprite);
            arrowHandler.Draw(spriteBatch, arrowDown,ArrowProj.arrowDown);
            arrowHandler.Draw(spriteBatch, arrowUp, ArrowProj.arrowUp);
            arrowHandler.Draw(spriteBatch, arrowLeft, ArrowProj.arrowLeft);
            arrowHandler.Draw(spriteBatch, arrowRight, ArrowProj.arrowRight);
            boomerangHandler.Draw(spriteBatch, boomerang, BoomerangProj.boomerang);

            foreach (Blocks b in Blocks.blocks)
            {
                spriteBatch.Draw(GeneralBlockSprite, b.Position, Color.White);
            }

            if (player.Health > 0)
            {
                player.anim.Draw(spriteBatch, player.Position,player.Pcolor);
            }
            else
            {
                deadLinkSpin.Draw(spriteBatch, player.Position, Color.White);
            }
            spriteBatch.DrawString(numOfKeysFont,player.NumOfKeys.ToString(), player.Position, Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
   
    
}
