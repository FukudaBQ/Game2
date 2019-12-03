
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game2.Factory;
using Game2.Sprites.Link;
using Game2.Sprites.Blocks;
using Game2.Sprites.Enemies;
using Game2.Object.Items;
using System.Collections.Generic;
using System;
using Game2.Collision;

using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Game2.Sprites.Link.Projectile;
using Game2.Commands;
using Microsoft.Xna.Framework.Input;
using HUDManager;
using Game2.Puzzle;
using Game2.Object;
using Game2.RandomEvent;
//using Game2.Object.Enemies;

namespace Game2
{
    public enum Dir
    {
        Down,Up,Left,Right,DownSword,UpSword,LeftSword,RightSword
    }

    public static class MySounds
    {
        public static SoundEffect attack;
        public static Song overworld;
        public static SoundEffect dead;
        public static SoundEffect random;
    }
    public class Game1 : Game
    {
        private String debug ="triforece location: ";
        private SpriteFont youWIN;
        private Texture2D LinkCheeringSprite;
        private Animate LinkCheering;
        
        private Texture2D deadLinkSprite;
        private Animate deadLinkSpin;
        BombHandler bombHandler = new BombHandler();
        ArrowHandler arrowHandler = new ArrowHandler();
        BoomerangHandler boomerangHandler = new BoomerangHandler();
        PokeballHandler pokeballHandler = new PokeballHandler();
        PortalGunHandler portalGunHandler = new PortalGunHandler();
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Player player;
        private Texture2D bomb;
        private Texture2D arrowDown;
        private Texture2D arrowUp;
        private Texture2D arrowLeft;
        private Texture2D arrowRight;
        private Texture2D boomerang;
        private Texture2D pokeball;
        private Texture2D portalGun;
        private Texture2D handSprite;
        private Texture2D knightSprite;
        private Texture2D batSprite;
        private Texture2D explosionSprite;
        private Texture2D lightSprite;
        private Texture2D monsterSprite;
        private Texture2D GeneralBlockSprite;
        private Texture2D BlackBlockSprite;
        private Texture2D fireballSprite;
        private Texture2D dragonSprite;
        private Texture2D yellowB;
        private Texture2D blueB;
        private Texture2D HUD;
        private Texture2D HUDMap;
        private Texture2D veryGreen;
        private Texture2D rockSprite;
        private Texture2D blackHoleSprite;
        private Texture2D leftDoor;
        private Texture2D rightDoor;
        private Texture2D downDoor;
        private Texture2D hintSprite;
        private Texture2D batHintSprite;
        private Texture2D slowDownHintSprite;
        private Texture2D sokobanSprite;
        private Texture2D textForExtraContent;
        private Dir direction =Dir.Down;
        private Vector2 tempPosition;
        public static Vector2 tempBlackHole1Position;
        public static Vector2 tempBlackHole2Position;
        public static Vector2 tempBlackHole3Position;
        public static Vector2 tempBlackHole4Position;
        public Texture2D blackHoleAppearSprite;

        public static BlackHole blackHole1;
        public static BlackHole blackHole2;
        public static BlackHole blackHole3;
        public static BlackHole blackHole4;
        public static BlackHole blackHole5;
        //public static BlackHole blackHole6;

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
        private ResetCommand reset;
        // TODO
        private Sokoban sokoban;
        private int monsterType;
        private Hint hint;

        public HUD myHUD;
        private SpriteFont font;
        int condition = 0;

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
        public void ReloadContent()
        {
            TiledMapObject[] bats = myMap.GetLayer<TiledMapObjectLayer>("bat").Objects;
            foreach (var bat in bats)
            {
                Bat.bats.Add(new Bat(batSprite, new Vector2(bat.Position.X, bat.Position.Y + 840), spriteBatch));

            }
            TiledMapObject[] specialbat = myMap.GetLayer<TiledMapObjectLayer>("specialBat").Objects;
            foreach (var bat in specialbat)
            {
                Bat.specialbats.Add(new Bat(batSprite, new Vector2(bat.Position.X, bat.Position.Y + 840), spriteBatch));

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
            TiledMapObject[] rknights = myMap.GetLayer<TiledMapObjectLayer>("redKnight").Objects;
            foreach (var rknight in rknights)
            {
                RedKnight.rknights.Add(new RedKnight(knightSprite, new Vector2(rknight.Position.X, rknight.Position.Y + 840), spriteBatch));

            }
            TiledMapObject[] gknights = myMap.GetLayer<TiledMapObjectLayer>("greenKnight").Objects;
            foreach (var gknight in gknights)
            {
                GreenKnight.gknights.Add(new GreenKnight(knightSprite, new Vector2(gknight.Position.X, gknight.Position.Y + 840), spriteBatch));

            }
            TiledMapObject[] yknights = myMap.GetLayer<TiledMapObjectLayer>("yellowKnight").Objects;
            foreach (var yknight in yknights)
            {
                YellowKnight.yknights.Add(new YellowKnight(knightSprite, new Vector2(yknight.Position.X, yknight.Position.Y + 840), spriteBatch));

            }
            TiledMapObject[] bknights = myMap.GetLayer<TiledMapObjectLayer>("blueKnight").Objects;
            foreach (var bknight in bknights)
            {
                BlueKnight.bknights.Add(new BlueKnight(knightSprite, new Vector2(bknight.Position.X, bknight.Position.Y + 840), spriteBatch));

            }


        }

        public void ClearContent()
        {
            Bat.bats.RemoveAll(e => e.Health >0);
            Dragon.dragons.RemoveAll(d => d.Health > 0);
            Knight.knights.RemoveAll(k => k.Health > 0);
            RedKnight.rknights.RemoveAll(rk => rk.Health > 0);
            GreenKnight.gknights.RemoveAll(gk => gk.Health > 0);
            YellowKnight.yknights.RemoveAll(yk => yk.Health > 0);
            BlueKnight.bknights.RemoveAll(bk => bk.Health > 0);


        }
        protected override void LoadContent()
        {
            reset = new ResetCommand(player,this,myHUD);
            youWIN = Content.Load<SpriteFont>("youWIN");
            myMap = Content.Load<TiledMap>("map/mapD");
            blackHoleSprite = Content.Load<Texture2D>("blackHole");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            ItemFactory.Instance.LoadAllTextures(Content);
            player = new Player(this);
            Register();

            myHUD = new HUD(player, HUD, spriteBatch, HUDMap, veryGreen);
            player.setHUD(myHUD);

            
            tempBlackHole1Position = new Vector2(player.Position.X, player.Position.Y + 100000);
            tempBlackHole2Position = new Vector2(player.Position.X, player.Position.Y + 200000);
            blackHole1 = new BlackHole(tempBlackHole1Position);
            blackHole2 = new BlackHole(tempBlackHole2Position);
            tempBlackHole3Position = new Vector2(player.Position.X, player.Position.Y + 100000);
            tempBlackHole4Position = new Vector2(player.Position.X, player.Position.Y + 200000);
            blackHole3 = new BlackHole(new Vector2(3450, 6400));
            //blackHole3.Able = true;
            blackHole4 = new BlackHole(new Vector2(3300, 6500));
            //blackHole4.Able = true;
            //blackHole3 = new BlackHole(tempBlackHole3Position);
            //blackHole4 = new BlackHole(tempBlackHole4Position);

            blackHole5 = new BlackHole(new Vector2(2980, 12800));
            //blackHole6 = new BlackHole(new Vector2(5540, 12800));

            // TODO
            sokoban = new Sokoban(sokobanSprite, spriteBatch, 12360, 12920, 5340, 6220, blackHoleSprite, textForExtraContent);
            player.setSokoban(sokoban);

            bat = new Bat(batSprite, new Vector2(2000, 1240), spriteBatch);
            dragon = new Dragon(dragonSprite, new Vector2(500, 3000), spriteBatch);
            key = new Key2( new Vector2(400, 2700), spriteBatch);
            monster = new Monster(monsterSprite, new Vector2(1500, 1000), spriteBatch);
            hand = new Hand(handSprite, new Vector2(1500, 3000), spriteBatch);
            knight = new Knight(knightSprite, new Vector2(5500, 1900), spriteBatch);
            deadLinkSprite = Content.Load<Texture2D>("LinkStand4Directions");
            deadLinkSpin = new Animate(deadLinkSprite, 1, 4);
            LinkCheeringSprite = Content.Load<Texture2D>("LinkCheering");
            LinkCheering = new Animate(LinkCheeringSprite, 1, 2);
            hint = new Hint(hintSprite, new Vector2(2000, 6100), spriteBatch);

            TiledMapObject[] bats = myMap.GetLayer<TiledMapObjectLayer>("bat").Objects;
            foreach (var bat in bats)
            {
                Bat.bats.Add(new Bat(batSprite, new Vector2(bat.Position.X, bat.Position.Y + 840), spriteBatch));
                
            }
            TiledMapObject[] rknights = myMap.GetLayer<TiledMapObjectLayer>("redKnight").Objects;
            foreach (var rknight in rknights)
            {
                RedKnight.rknights.Add(new RedKnight(knightSprite, new Vector2(rknight.Position.X, rknight.Position.Y + 840), spriteBatch));

            }
            TiledMapObject[] gknights = myMap.GetLayer<TiledMapObjectLayer>("greenKnight").Objects;
            foreach (var gknight in gknights)
            {
                GreenKnight.gknights.Add(new GreenKnight(knightSprite, new Vector2(gknight.Position.X, gknight.Position.Y + 840), spriteBatch));

            }
            TiledMapObject[] yknights = myMap.GetLayer<TiledMapObjectLayer>("yellowKnight").Objects;
            foreach (var yknight in yknights)
            {
                YellowKnight.yknights.Add(new YellowKnight(knightSprite, new Vector2(yknight.Position.X, yknight.Position.Y + 840), spriteBatch));

            }
            TiledMapObject[] bknights = myMap.GetLayer<TiledMapObjectLayer>("blueKnight").Objects;
            foreach (var bknight in bknights)
            {
                BlueKnight.bknights.Add(new BlueKnight(knightSprite, new Vector2(bknight.Position.X, bknight.Position.Y + 840), spriteBatch));

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

            TiledMapObject[] hintKnights = myMap.GetLayer<TiledMapObjectLayer>("hintKnight").Objects;
            foreach (var hkn in hintKnights)
            {
                HintKnight.hintKnights.Add(new HintKnight(knightSprite, new Vector2(hkn.Position.X, hkn.Position.Y + 840), spriteBatch));

            }

            TiledMapObject[] triforces = myMap.GetLayer<TiledMapObjectLayer>("triforce").Objects;
            foreach (var tri in triforces)
            {
                Item.items.Add(new Triforce2(new Vector2(tri.Position.X, tri.Position.Y + 800), spriteBatch));
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
            TiledMapObject[] button = myMap.GetLayer<TiledMapObjectLayer>("restartButton").Objects;
            foreach (var r in button)
            {
                Item.items.Add(new Button(new Vector2(r.Position.X, r.Position.Y + 840),spriteBatch));
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
            
            TiledMapObject[] leftdoors = myMap.GetLayer<TiledMapObjectLayer>("leftdoor").Objects;
            foreach (var ldoor in leftdoors)
            {
                Door.leftdoors.Add(new Doors(new Vector2(ldoor.Position.X, ldoor.Position.Y + 840)));
            }
            TiledMapObject[] downdoors = myMap.GetLayer<TiledMapObjectLayer>("downdoor").Objects;
            foreach (var ddoor in downdoors)
            {
                Door.downdoors.Add(new Doors(new Vector2(ddoor.Position.X, ddoor.Position.Y + 840)));
            }
            TiledMapObject[] rightdoors = myMap.GetLayer<TiledMapObjectLayer>("rightdoor").Objects;
            foreach (var rdoor in rightdoors)
            {
                Door.rightdoors.Add(new Doors(new Vector2(rdoor.Position.X, rdoor.Position.Y + 840)));
            }
            TiledMapObject[] rocks = myMap.GetLayer<TiledMapObjectLayer>("rock").Objects;
            foreach (var r in rocks)
            {
                Rock.rocks.Add(new RockBlock(new Vector2(r.Position.X, r.Position.Y + 840)));
            }
            TiledMapObject[] waterblocks = myMap.GetLayer<TiledMapObjectLayer>("waterblock").Objects;
            foreach (var wblo in waterblocks)
            {
                
                Blocks.waterblocks.Add(new GeneralBlock(new Vector2(wblo.Position.X, wblo.Position.Y + 840)));
            }
            TiledMapObject[] blackblocks = myMap.GetLayer<TiledMapObjectLayer>("blackblock").Objects;
            foreach (var wblo in blackblocks)
            {

                Blocks.blackblocks.Add(new GeneralBlock(new Vector2(wblo.Position.X, wblo.Position.Y + 840)));
            }
            TiledMapObject[] pokeballs = myMap.GetLayer<TiledMapObjectLayer>("pokeball").Objects;
            foreach (var poke in pokeballs)
            {
                Pokeball.pokeballs.Add(new Pokeball(new Vector2(poke.Position.X, poke.Position.Y + 840),direction));
            }
            TiledMapObject[] portalGuns = myMap.GetLayer<TiledMapObjectLayer>("gun").Objects;
            foreach (var poke in portalGuns)
            {
                PortalGun.portalGuns.Add(new PortalGun(new Vector2(poke.Position.X, poke.Position.Y + 840), direction));
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
            pokeball = Content.Load<Texture2D>("pokeball");
            portalGun = Content.Load<Texture2D>("portalGun");
            GeneralBlockSprite = Content.Load<Texture2D>("GeneralBlock");
            BlackBlockSprite = Content.Load<Texture2D>("black");
            batSprite = Content.Load<Texture2D>("bat");
            explosionSprite= Content.Load<Texture2D>("biggerExplosion1");
            lightSprite = Content.Load<Texture2D>("light");
            dragonSprite = Content.Load<Texture2D>("Dragon");
            yellowB = Content.Load<Texture2D>("YellowB");
            blueB = Content.Load<Texture2D>("BlueB");
            fireballSprite = Content.Load<Texture2D>("fireball");
            monsterSprite =Content.Load<Texture2D>("monster");
            handSprite = Content.Load<Texture2D>("hand");
            knightSprite = Content.Load<Texture2D>("knight");
            MySounds.attack = Content.Load<SoundEffect>("music/UseSword");
            MySounds.overworld = Content.Load<Song>("music/Dungeon");
            MySounds.dead = Content.Load<SoundEffect>("music/GameOver");
            MySounds.random = Content.Load<SoundEffect>("music/randomEvents");
            MediaPlayer.Play(MySounds.overworld);
            HUD = Content.Load<Texture2D>("HUD");
            HUDMap = Content.Load<Texture2D>("small_map");
            veryGreen = Content.Load<Texture2D>("Green");
            rockSprite = Content.Load<Texture2D>("rock");
            font = Content.Load<SpriteFont>("NMNAT");
            rightDoor = Content.Load<Texture2D>("door1");
            leftDoor = Content.Load<Texture2D>("door2");
            downDoor = Content.Load<Texture2D>("door3");
            hintSprite = Content.Load<Texture2D>("hint");
            batHintSprite = Content.Load<Texture2D>("batSpeedUp");
            slowDownHintSprite = Content.Load<Texture2D>("LinkSpeedDown");
            blackHoleAppearSprite = Content.Load<Texture2D>("blackHolesAppear");
            textForExtraContent = Content.Load<Texture2D>("TextForSokoban");
            sokobanSprite = Content.Load<Texture2D>("box");
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            blackHole1.Update(gameTime,player,blackHole2);
            blackHole2.Update(gameTime,player,blackHole1);
            if (blackHole3 != null && blackHole4 != null)
            {
                blackHole3.Update(gameTime, player, blackHole4);
                blackHole4.Update(gameTime, player, blackHole3);
            }
            blackHole3.Update(gameTime, player, blackHole4);
            blackHole4.Update(gameTime, player, blackHole3);
            player.camPosition = blackHole5.Update(gameTime, player, 0, player.camPosition);
            //player.camPosition = blackHole6.Update(gameTime, player, blackHole5, 1, player.camPosition);

            hint.Update(gameTime);
            LinkCheering.Update(gameTime);
            deadLinkSpin.Update(gameTime);
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (player.Health > 0&&!player.Victory)
            {
                player.Update(gameTime);
            }
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
            foreach (BlackHoleAppear bh in BlackHoleAppear.bha)
            {
                bh.Update(gameTime);
            }
            foreach (light ex in light.lig)
            {
                ex.Update(gameTime);
            }
            foreach (SpeedUp su in SpeedUp.spd)
            {
                su.Update(gameTime);
            }
            foreach (SlowDown sd in SlowDown.sld)
            {
                sd.Update(gameTime);
            }
            foreach (Knight kn in Knight.knights)
            {
                kn.Update(gameTime);
                int sum = player.Radius + kn.Radius;
                if (Vector2.Distance(player.Position, kn.Location) < sum && player.HealthTimer <= 0)
                {

                    player.Health--;
                    myHUD.LostHeart();
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
            foreach (HintKnight hkn in HintKnight.hintKnights)
            {
                hkn.Update(gameTime);

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
                    myHUD.LostHeart();
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
            foreach (Bat bat in Bat.batF)
            {
                bat.Update2(gameTime, player.position);
            }
            foreach (Knight knight in Knight.knightF)
            {
                knight.Update2(gameTime);
            }
            foreach (Bat bat in Bat.specialbats)
            {
                bat.UpdateS(gameTime, player.position);
            }
                foreach (Bat bat in Bat.bats)
            {
                bat.Update(gameTime, player.position);
                int sum = player.Radius + bat.Radius;
                if (Vector2.Distance(player.Position, bat.Location) < sum&&player.HealthTimer<=0)
                {
                    
                    player.Health--;
                    myHUD.LostHeart();
                    Vector2 moveDir =player.Position - bat.Location;
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
            foreach (RedKnight rknight in RedKnight.rknights)
            {
                rknight.Update(gameTime);
                int sum = player.Radius + rknight.Radius;
                if (Vector2.Distance(player.Position, rknight.Location) < sum && player.HealthTimer <= 0)
                {

                    player.Health--;
                    myHUD.LostHeart();
                    Vector2 moveDir = player.Position - rknight.Location;
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
            foreach (GreenKnight gknight in GreenKnight.gknights)
            {
                gknight.Update(gameTime);
                int sum = player.Radius + gknight.Radius;
                if (Vector2.Distance(player.Position, gknight.Location) < sum && player.HealthTimer <= 0)
                {

                    player.Health--;
                    myHUD.LostHeart();
                    Vector2 moveDir = player.Position - gknight.Location;
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
            foreach (BlueKnight bknight in BlueKnight.bknights)
            {
                bknight.Update(gameTime);
                int sum = player.Radius + bknight.Radius;
                if (Vector2.Distance(player.Position, bknight.Location) < sum && player.HealthTimer <= 0)
                {

                    player.Health--;
                    myHUD.LostHeart();
                    Vector2 moveDir = player.Position - bknight.Location;
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
            foreach (YellowKnight yknight in YellowKnight.yknights)
            {
                yknight.Update(gameTime);
                int sum = player.Radius + yknight.Radius;
                if (Vector2.Distance(player.Position, yknight.Location) < sum && player.HealthTimer <= 0)
                {

            //foreach (Pokeball b in Pokeball.pokeballProj)
            //{
            // foreach (Bat bat in Bat.bats)
            // {
            // int sum = b.Radius + bat.Radius;
            // if (Vector2.Distance(b.Position, bat.location) < sum)
            // {
            // b.Collided = true;
            // bat.Health--;
            // if (bat.Health <= 0)
            //{
            //  explosion.exp.Add(new explosion(bat.location));

            // }
            // }
            // }


            //}
            //Pokeball.pokeballProj.RemoveAll(p => p.Collided == true);
            




                    player.Health--;
                    myHUD.LostHeart();
                    Vector2 moveDir = player.Position - yknight.Location;
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

            foreach (Pokeball b in Pokeball.pokeballwithMonsterProj)
            {
                if (b.Speed == 0)
                {
                    tempPosition = b.Position;
                }
                monsterType = b.Monster;
            }
            if (Pokeball.pokeballwithMonsterProj.RemoveAll(p => p.Speed == 0) == 1)
            {
                if (monsterType == 1)
                {
                    Bat.batF.Add(new Bat(batSprite, tempPosition, spriteBatch));
                }
                else if (monsterType == 2)
                {
                    Knight.knightF.Add(new Knight(knightSprite, tempPosition, spriteBatch));
                }
            }

            foreach (BombProj b in BombProj.bomb)
            {
                foreach (Bat bat in Bat.bats)
                {
                    int sum = b.Radius + bat.Radius;
                    if (Vector2.Distance(b.Position, bat.Location) < sum)
                    {
                        b.Collided = true;
                        bat.Health--;
                        if (bat.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bat.Location));
                        }
                    }
                }
                foreach (Rock r in Rock.rocks)
                {
                    int sum = b.Radius + r.Radius;
                    if (Vector2.Distance(b.Position, r.Position) < sum)
                    {
                        b.Collided = true;
                        r.Health = 0;
                        if (r.Health == 0)
                        {
                            explosion.exp.Add(new explosion(r.Position));
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
                foreach (Knight kn in Knight.knights)
                {
                    int sum = b.Radius + kn.Radius;
                    if (Vector2.Distance(b.Position, kn.Location) < sum)
                    {
                        b.Collided = true;
                        kn.Health--;
                        if (kn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(kn.Location));
                        }
                    }

                }
                foreach (RedKnight rkn in RedKnight.rknights)
                {
                    int sum = b.Radius + rkn.Radius;
                    if (Vector2.Distance(b.Position, rkn.Location) < sum)
                    {
                        b.Collided = true;
                        rkn.Health--;
                        if (rkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(rkn.Location));
                            condition++;
                        }
                    }

                }
                foreach (BlueKnight bkn in BlueKnight.bknights)
                {
                    int sum = b.Radius + bkn.Radius;
                    if (Vector2.Distance(b.Position, bkn.Location) < sum)
                    {
                        b.Collided = true;
                        bkn.Health--;
                        if (bkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bkn.Location));
                            if (condition == 1)
                            {
                                condition++;
                            }
                        }
                    }

                }
                foreach (GreenKnight gkn in GreenKnight.gknights)
                {
                    int sum = b.Radius + gkn.Radius;
                    if (Vector2.Distance(b.Position, gkn.Location) < sum)
                    {
                        b.Collided = true;
                        gkn.Health--;
                        if (gkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(gkn.Location));
                            if (condition == 2)
                            {
                                condition++;
                            }
                        }
                    }

                }
                foreach (YellowKnight ykn in YellowKnight.yknights)
                {
                    int sum = b.Radius + ykn.Radius;
                    if (Vector2.Distance(b.Position, ykn.Location) < sum)
                    {
                        b.Collided = true;
                        ykn.Health--;
                        if (ykn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(ykn.Location));
                            if (condition == 3)
                            {
                                condition++;
                            }
                        }
                    }

                }
            }
            foreach (BoomerangProj boo in BoomerangProj.boomerang)
            {
                if (Blocks.didCollide(boo.Position, 10, 10))
                {
                    boo.Collided = true;
                }
                foreach (Bat bat in Bat.bats)
                {
                    int sum = boo.Radius + bat.Radius;
                    if (Vector2.Distance(boo.Position, bat.Location) < sum)
                    {
                        boo.Collided = true;
                        bat.Health--;
                        if (bat.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bat.Location));
                        }
                    }

                }
                foreach (Dragon dra in Dragon.dragons)
                {
                    int sum = boo.Radius + dra.Radius;
                    if (Vector2.Distance(boo.Position, dra.Location) < sum)
                    {
                        boo.Collided = true;
                        dra.Health--;
                        if (dra.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(dra.Location));
                        }
                    }

                }
                foreach (Knight kn in Knight.knights)
                {
                    int sum = boo.Radius + kn.Radius;
                    if (Vector2.Distance(boo.Position, kn.Location) < sum)
                    {
                        boo.Collided = true;
                        kn.Health--;
                        if (kn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(kn.Location));
                        }
                    }

                }
                foreach (RedKnight rkn in RedKnight.rknights)
                {
                    int sum = boo.Radius + rkn.Radius;
                    if (Vector2.Distance(boo.Position, rkn.Location) < sum)
                    {
                        boo.Collided = true;
                        rkn.Health--;
                        if (rkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(rkn.Location));
                            condition++;
                        }
                    }

                }
                foreach (BlueKnight bkn in BlueKnight.bknights)
                {
                    int sum = boo.Radius + bkn.Radius;
                    if (Vector2.Distance(boo.Position, bkn.Location) < sum)
                    {
                        boo.Collided = true;
                        bkn.Health--;
                        if (bkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bkn.Location));
                            if (condition == 1)
                            {
                                condition++;
                            }
                        }
                    }

                }
                foreach (GreenKnight gkn in GreenKnight.gknights)
                {
                    int sum = boo.Radius + gkn.Radius;
                    if (Vector2.Distance(boo.Position, gkn.Location) < sum)
                    {
                        boo.Collided = true;
                        gkn.Health--;
                        if (gkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(gkn.Location));
                            if (condition == 2)
                            {
                                condition++;
                            }
                        }
                    }

                }
                foreach (YellowKnight ykn in YellowKnight.yknights)
                {
                    int sum = boo.Radius + ykn.Radius;
                    if (Vector2.Distance(boo.Position, ykn.Location) < sum)
                    {
                        boo.Collided = true;
                        ykn.Health--;
                        if (ykn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(ykn.Location));
                            if (condition == 3)
                            {
                                condition++;
                            }
                        }
                    }

                }
            }
            foreach (ArrowProj arrow in ArrowProj.arrowLeft)
            {
                int sum1 = arrow.Radius + blackHole1.Radius;
                int sum2 = arrow.Radius + blackHole2.Radius;
                int sum3= arrow.Radius + blackHole3.Radius;
                int sum4 = arrow.Radius + blackHole4.Radius;
                if (blackHole1.Able&&blackHole2.Able&&Vector2.Distance(arrow.Position, blackHole1.Position) < sum1 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole2.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }
                if (blackHole1.Able && blackHole2.Able && Vector2.Distance(arrow.Position, blackHole2.Position) < sum2 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole1.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }
                if (blackHole3.Able && blackHole4.Able && Vector2.Distance(arrow.Position, blackHole3.Position) < sum3 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole4.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }
                if (blackHole3.Able && blackHole4.Able && Vector2.Distance(arrow.Position, blackHole4.Position) < sum4 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole3.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }
                if (Blocks.didCollide(arrow.Position, 10, 10))
                {
                    arrow.Collided = true;
                }
                foreach (Bat bat in Bat.bats)
                {
                    int sum = arrow.Radius + bat.Radius;
                    if (Vector2.Distance(arrow.Position, bat.Location) < sum)
                    {
                        arrow.Collided = true;
                        bat.Health--;
                        if (bat.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bat.Location));
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
                foreach (Knight kn in Knight.knights)
                {
                    int sum = arrow.Radius + kn.Radius;
                    if (Vector2.Distance(arrow.Position, kn.Location) < sum)
                    {
                        arrow.Collided = true;
                        kn.Health--;
                        if (kn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(kn.Location));
                        }
                    }

                }
                foreach (RedKnight rkn in RedKnight.rknights)
                {
                    int sum = arrow.Radius + rkn.Radius;
                    if (Vector2.Distance(arrow.Position, rkn.Location) < sum)
                    {
                        arrow.Collided = true;
                        rkn.Health--;
                        if (rkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(rkn.Location));
                            condition++;
                        }
                    }

                }
                foreach (BlueKnight bkn in BlueKnight.bknights)
                {
                    int sum = arrow.Radius + bkn.Radius;
                    if (Vector2.Distance(arrow.Position, bkn.Location) < sum)
                    {
                        arrow.Collided = true;
                        bkn.Health--;
                        if (bkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bkn.Location));
                            if (condition == 1)
                            {
                                condition++;
                            }
                        }
                    }

                }
                foreach (GreenKnight gkn in GreenKnight.gknights)
                {
                    int sum = arrow.Radius + gkn.Radius;
                    if (Vector2.Distance(arrow.Position, gkn.Location) < sum)
                    {
                        arrow.Collided = true;
                        gkn.Health--;
                        if (gkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(gkn.Location));
                            if (condition == 2)
                            {
                                condition++;
                            }
                        }
                    }

                }
                foreach (YellowKnight ykn in YellowKnight.yknights)
                {
                    int sum = arrow.Radius + ykn.Radius;
                    if (Vector2.Distance(arrow.Position, ykn.Location) < sum)
                    {
                        arrow.Collided = true;
                        ykn.Health--;
                        if (ykn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(ykn.Location));
                            if (condition == 3)
                            {
                                condition++;
                            }
                        }
                    }

                }
                foreach (Bat b in Bat.specialbats)
                {
                    int sum = arrow.Radius + b.Radius;
                    if (Vector2.Distance(arrow.Position, b.Location) < sum)
                    {
                        arrow.Collided = true;
                        b.Health--;
                        if (b.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(b.Location));
                            
                        }
                    }

                }
            }
            foreach (ArrowProj arrow in ArrowProj.arrowRight)
            {
                int sum1 = arrow.Radius + blackHole1.Radius;
                int sum2 = arrow.Radius + blackHole2.Radius;
                int sum3 = arrow.Radius + blackHole3.Radius;
                int sum4 = arrow.Radius + blackHole4.Radius;
                if (blackHole1.Able && blackHole2.Able && Vector2.Distance(arrow.Position, blackHole1.Position) < sum1 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole2.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }
                if (blackHole1.Able && blackHole2.Able && Vector2.Distance(arrow.Position, blackHole2.Position) < sum2 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole1.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }
                if (blackHole3.Able && blackHole4.Able && Vector2.Distance(arrow.Position, blackHole3.Position) < sum3 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole4.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }
                if (blackHole3.Able && blackHole4.Able && Vector2.Distance(arrow.Position, blackHole4.Position) < sum4 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole3.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }   
                if (Blocks.didCollide(arrow.Position, 10, 10))
                {
                    arrow.Collided = true;
                }
                foreach (Bat b in Bat.specialbats)
                {
                    int sum = arrow.Radius + b.Radius;
                    if (Vector2.Distance(arrow.Position, b.Location) < sum)
                    {
                        arrow.Collided = true;
                        b.Health--;
                        if (b.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(b.Location));

                        }
                    }

                }
                foreach (Bat bat in Bat.bats)
                {
                    int sum = arrow.Radius + bat.Radius;
                    if (Vector2.Distance(arrow.Position, bat.Location) < sum)
                    {
                        arrow.Collided = true;
                        bat.Health--;
                        if (bat.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bat.Location));
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
                foreach (Knight kn in Knight.knights)
                {
                    int sum = arrow.Radius + kn.Radius;
                    if (Vector2.Distance(arrow.Position, kn.Location) < sum)
                    {
                        arrow.Collided = true;
                        kn.Health--;
                        if (kn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(kn.Location));
                        }
                    }

                }
                foreach (RedKnight rkn in RedKnight.rknights)
                {
                    int sum = arrow.Radius + rkn.Radius;
                    if (Vector2.Distance(arrow.Position, rkn.Location) < sum)
                    {
                        arrow.Collided = true;
                        rkn.Health--;
                        if (rkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(rkn.Location));
                            condition++;
                        }
                    }

                }
                foreach (BlueKnight bkn in BlueKnight.bknights)
                {
                    int sum = arrow.Radius + bkn.Radius;
                    if (Vector2.Distance(arrow.Position, bkn.Location) < sum)
                    {
                        arrow.Collided = true;
                        bkn.Health--;
                        if (bkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bkn.Location));
                            if (condition == 1)
                            {
                                condition++;
                            }
                        }
                    }

                }
                foreach (GreenKnight gkn in GreenKnight.gknights)
                {
                    int sum = arrow.Radius + gkn.Radius;
                    if (Vector2.Distance(arrow.Position, gkn.Location) < sum)
                    {
                        arrow.Collided = true;
                        gkn.Health--;
                        if (gkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(gkn.Location));
                            if (condition == 2)
                            {
                                condition++;
                            }
                        }
                    }

                }
                foreach (YellowKnight ykn in YellowKnight.yknights)
                {
                    int sum = arrow.Radius + ykn.Radius;
                    if (Vector2.Distance(arrow.Position, ykn.Location) < sum)
                    {
                        arrow.Collided = true;
                        ykn.Health--;
                        if (ykn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(ykn.Location));
                            if (condition == 3)
                            {
                                condition++;
                            }
                        }
                    }

                }
            }
            foreach (ArrowProj arrow in ArrowProj.arrowUp)
            {
                int sum1 = arrow.Radius + blackHole1.Radius;
                int sum2 = arrow.Radius + blackHole2.Radius;
                int sum3 = arrow.Radius + blackHole3.Radius;
                int sum4 = arrow.Radius + blackHole4.Radius;
                if (blackHole1.Able && blackHole2.Able && Vector2.Distance(arrow.Position, blackHole1.Position) < sum1 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole2.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }
                if (blackHole1.Able && blackHole2.Able && Vector2.Distance(arrow.Position, blackHole2.Position) < sum2 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole1.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }
                if (blackHole3.Able && blackHole4.Able && Vector2.Distance(arrow.Position, blackHole3.Position) < sum3 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole4.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }
                if (blackHole3.Able && blackHole4.Able && Vector2.Distance(arrow.Position, blackHole4.Position) < sum4 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole3.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }


                if (Blocks.didCollide(arrow.Position, 10, 10))
                {
                    arrow.Collided = true;
                }
                foreach (Bat b in Bat.specialbats)
                {
                    int sum = arrow.Radius + b.Radius;
                    if (Vector2.Distance(arrow.Position, b.Location) < sum)
                    {
                        arrow.Collided = true;
                        b.Health--;
                        if (b.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(b.Location));

                        }
                    }

                }
                foreach (Bat bat in Bat.bats)
                {
                    int sum = arrow.Radius + bat.Radius;
                    if (Vector2.Distance(arrow.Position, bat.Location) < sum)
                    {
                        arrow.Collided = true;
                        bat.Health--;
                        if (bat.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bat.Location));
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
                foreach (Knight kn in Knight.knights)
                {
                    int sum = arrow.Radius + kn.Radius;
                    if (Vector2.Distance(arrow.Position, kn.Location) < sum)
                    {
                        arrow.Collided = true;
                        kn.Health--;
                        if (kn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(kn.Location));
                        }
                    }

                }
                foreach (RedKnight rkn in RedKnight.rknights)
                {
                    int sum = arrow.Radius + rkn.Radius;
                    if (Vector2.Distance(arrow.Position, rkn.Location) < sum)
                    {
                        arrow.Collided = true;
                        rkn.Health--;
                        if (rkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(rkn.Location));
                            condition++;
                        }
                    }

                }
                foreach (BlueKnight bkn in BlueKnight.bknights)
                {
                    int sum = arrow.Radius + bkn.Radius;
                    if (Vector2.Distance(arrow.Position, bkn.Location) < sum)
                    {
                        arrow.Collided = true;
                        bkn.Health--;
                        if (bkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bkn.Location));
                            if (condition == 1)
                            {
                                condition++;
                            }
                        }
                    }

                }
                foreach (GreenKnight gkn in GreenKnight.gknights)
                {
                    int sum = arrow.Radius + gkn.Radius;
                    if (Vector2.Distance(arrow.Position, gkn.Location) < sum)
                    {
                        arrow.Collided = true;
                        gkn.Health--;
                        if (gkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(gkn.Location));
                            if (condition == 2)
                            {
                                condition++;
                            }
                        }
                    }

                }
                foreach (YellowKnight ykn in YellowKnight.yknights)
                {
                    int sum = arrow.Radius + ykn.Radius;
                    if (Vector2.Distance(arrow.Position, ykn.Location) < sum)
                    {
                        arrow.Collided = true;
                        ykn.Health--;
                        if (ykn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(ykn.Location));
                            if (condition == 3)
                            {
                                condition++;
                            }
                        }
                    }

                }
            }
            foreach (ArrowProj arrow in ArrowProj.arrowDown)
            {
                int sum1 = arrow.Radius + blackHole1.Radius;
                int sum2 = arrow.Radius + blackHole2.Radius;
                int sum3 = arrow.Radius + blackHole3.Radius;
                int sum4 = arrow.Radius + blackHole4.Radius;
                if (blackHole1.Able && blackHole2.Able && Vector2.Distance(arrow.Position, blackHole1.Position) < sum1 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole2.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }
                if (blackHole1.Able && blackHole2.Able && Vector2.Distance(arrow.Position, blackHole2.Position) < sum2 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole1.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }
                if (blackHole3.Able && blackHole4.Able && Vector2.Distance(arrow.Position, blackHole3.Position) < sum3 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole4.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }
                if (blackHole3.Able && blackHole4.Able && Vector2.Distance(arrow.Position, blackHole4.Position) < sum4 && arrow.BlackHoleTimer <= 0)
                {
                    arrow.Position = blackHole3.Position;
                    arrow.BlackHoleTimer = 1.5f;
                }

                if (Blocks.didCollide(arrow.Position, 10, 10))
                {
                    arrow.Collided = true;
                }
                
                foreach (Bat bat in Bat.bats)
                {
                    int sum = arrow.Radius + bat.Radius;
                    if (Vector2.Distance(arrow.Position, bat.Location) < sum)
                    {
                        arrow.Collided = true;
                        bat.Health--;
                        if (bat.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bat.Location));
                        }
                    }
                }
                foreach (Bat b in Bat.specialbats)
                {
                    int sum = arrow.Radius + b.Radius;
                    if (Vector2.Distance(arrow.Position, b.Location) < sum)
                    {
                        arrow.Collided = true;
                        b.Health--;
                        if (b.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(b.Location));

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
                foreach (Knight kn in Knight.knights)
                {
                    int sum = arrow.Radius + kn.Radius;
                    if (Vector2.Distance(arrow.Position, kn.Location) < sum)
                    {
                        arrow.Collided = true;
                        kn.Health--;
                        if (kn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(kn.Location));
                        }
                    }

                }
                foreach (RedKnight rkn in RedKnight.rknights)
                {
                    int sum = arrow.Radius + rkn.Radius;
                    if (Vector2.Distance(arrow.Position, rkn.Location) < sum)
                    {
                        arrow.Collided = true;
                        rkn.Health--;
                        if (rkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(rkn.Location));
                            condition++;
                        }
                    }

                }
                foreach (BlueKnight bkn in BlueKnight.bknights)
                {
                    int sum = arrow.Radius + bkn.Radius;
                    if (Vector2.Distance(arrow.Position, bkn.Location) < sum)
                    {
                        arrow.Collided = true;
                        bkn.Health--;
                        if (bkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bkn.Location));
                            if (condition == 1)
                            {
                                condition++;
                            }
                        }
                    }

                }
                foreach (GreenKnight gkn in GreenKnight.gknights)
                {
                    int sum = arrow.Radius + gkn.Radius;
                    if (Vector2.Distance(arrow.Position, gkn.Location) < sum)
                    {
                        arrow.Collided = true;
                        gkn.Health--;
                        if (gkn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(gkn.Location));
                            if (condition == 2)
                            {
                                condition++;
                            }
                        }
                    }

                }
                foreach (YellowKnight ykn in YellowKnight.yknights)
                {
                    int sum = arrow.Radius + ykn.Radius;
                    if (Vector2.Distance(arrow.Position, ykn.Location) < sum)
                    {
                        arrow.Collided = true;
                        ykn.Health--;
                        if (ykn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(ykn.Location));
                            if (condition == 3)
                            {
                                condition++;
                            }
                        }
                    }

                }
            }

            if (condition == 4)
            {
                foreach (Door d in Door.leftdoors)
                {
                    d.Health--;
                }
                foreach (Door d in Door.downdoors)
                {
                    d.Health--;
                }
                foreach (Door d in Door.rightdoors)
                {
                    d.Health--;
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
                    myHUD.LostHeart();
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
                    myHUD.LostHeart();
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
                    myHUD.LostHeart();
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
            Bat.specialbats.RemoveAll(e => e.Health <= 0);
            Dragon.dragons.RemoveAll(d => d.Health <= 0);
            explosion.exp.RemoveAll(ex => ex.Timer <= 0);
            light.lig.RemoveAll(ex => ex.Timer <= 0);
            SpeedUp.spd.RemoveAll(su => su.Timer <= 0);
            SlowDown.sld.RemoveAll(sd => sd.Timer <= 0);
            BlackHoleAppear.bha.RemoveAll(bh => bh.Timer <= 0);
            fireball.fireDown.RemoveAll(f => f.Collided == true);
            fireball.fireUp.RemoveAll(f => f.Collided == true);
            fireball.fireLeft.RemoveAll(f => f.Collided == true);
            Knight.knights.RemoveAll(k => k.Health <= 0);
            RedKnight.rknights.RemoveAll(k => k.Health <= 0);
            GreenKnight.gknights.RemoveAll(k => k.Health <= 0);
            YellowKnight.yknights.RemoveAll(k => k.Health <= 0);
            BlueKnight.bknights.RemoveAll(k => k.Health <= 0);
            Rock.rocks.RemoveAll(r => r.Health <= 0);
            Door.leftdoors.RemoveAll(d => d.Health <= 0);
            Door.downdoors.RemoveAll(d => d.Health <= 0);
            Door.rightdoors.RemoveAll(d => d.Health <= 0);
            Knight.knightF.RemoveAll(p => p.Health == 0);
            Bat.batF.RemoveAll(p => p.Health == 0);
            CollisionHandler collisionHandler = new CollisionHandler();
            

            collisionHandler.CollisionHandle(player, myHUD,this);
            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.R))
            {
                player.Position = new Vector2(3140, 12800);
                player.camPosition = new Vector2(3200, 12520);
                player.Health = 3;
                player.bombNum = 5;
                myHUD = new HUD(player, HUD, spriteBatch, HUDMap, veryGreen);
                player.setHUD(myHUD);
            }


            bombHandler.Update(gameTime);
            arrowHandler.Update(gameTime);
            boomerangHandler.Update(gameTime,player);
            pokeballHandler.Update(gameTime, player);
            portalGunHandler.Update(gameTime, player);
            foreach(PortalGun p in PortalGun.blueBs)
            {
                if (p.Speed == 0)
                {

                    tempPosition = p.Position;
                }
            }
            foreach (PortalGun p in PortalGun.yellowBs)
            {
                if (p.Speed == 0)
                {

                    tempPosition = p.Position;
                }
            }

            if (PortalGun.blueBs.RemoveAll(p => p.Speed == 0) == 1)
            {

                PortalGun.portalGunStoB.Add(new PortalGun(tempBlackHole1Position, direction));
                blackHole3 = new BlackHole(tempPosition);
                blackHole3.Able = true;
                //tempBlackHole3Position = tempPosition;

            }

            if (PortalGun.yellowBs.RemoveAll(p => p.Speed == 0) == 1)
            {
                PortalGun.portalGunStoY.Add(new PortalGun(tempBlackHole1Position, direction));
                blackHole4 = new BlackHole(tempPosition);
                blackHole4.Able = true;
            }
            player.camPosition = sokoban.Update(gameTime, player, 1, player.camPosition);

            cam.LookAt(player.camPosition);

            base.Update(gameTime);

        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            
            mapRenderer.Draw(myMap, cam.GetViewMatrix());
            spriteBatch.Begin(transformMatrix:cam.GetViewMatrix());
            foreach (Blocks b in Blocks.blackblocks)
            {
                spriteBatch.Draw(BlackBlockSprite, b.Position, Color.White);
            }
            foreach (explosion ex in explosion.exp)
            {
                spriteBatch.Draw(explosionSprite, ex.Position, Color.White);
            }
            foreach (light ex in light.lig)
            {
                spriteBatch.Draw(lightSprite, ex.Position, Color.White);
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
            foreach (SpeedUp su in SpeedUp.spd)
            {
                spriteBatch.Draw(batHintSprite, su.Position, Color.White);
            }
            foreach (SlowDown sd in SlowDown.sld)
            {
                spriteBatch.Draw(slowDownHintSprite, sd.Position, Color.White);
            }
            foreach (BlackHoleAppear bh in BlackHoleAppear.bha)
            {
                spriteBatch.Draw(blackHoleAppearSprite, bh.Position, Color.White);
            }

            myHUD.Draw();
            hint.Draw();

            foreach (Bat bat in Bat.bats)
            {
                bat.Draw(bat.Location);
            }
            foreach (Bat bat in Bat.specialbats)
            {
                bat.Draw(bat.Location);
            }
            foreach (Bat bat in Bat.batF)
            {
                bat.Draw2(bat.Location);
            }
            foreach (RedKnight rknight in RedKnight.rknights)
            {
                rknight.Draw();
            }
            foreach (GreenKnight gknight in GreenKnight.gknights)
            {
                gknight.Draw();
            }
            foreach (BlueKnight bknight in BlueKnight.bknights)
            {
                bknight.Draw();
            }
            foreach (YellowKnight yknight in YellowKnight.yknights)
            {
                yknight.Draw();
            }
            foreach (HintKnight hknight in HintKnight.hintKnights)
            {
                hknight.Draw();
            }
            foreach (Dragon dra in Dragon.dragons)
            {
                dra.Draw(dra.Location);
            }

            foreach (Knight kn in Knight.knights)
            {
                kn.Draw();
            }
            foreach (Knight kn in Knight.knightF)
            {
                kn.Draw2();
            }
            foreach (Rock r in Rock.rocks)
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
            pokeballHandler.Draw(spriteBatch, pokeball, Pokeball.pokeballProj);
            pokeballHandler.Draw(spriteBatch, pokeball, Pokeball.pokeballs);
            pokeballHandler.Draw(spriteBatch, pokeball, Pokeball.pokeballwithMonster);
            pokeballHandler.Draw(spriteBatch, pokeball, Pokeball.pokeballwithMonsterProj);

            portalGunHandler.Draw(spriteBatch, portalGun, PortalGun.portalGuns);
            portalGunHandler.Draw(spriteBatch, yellowB, PortalGun.yellowBs);
            portalGunHandler.Draw(spriteBatch, blueB, PortalGun.blueBs);

            foreach (Blocks b in Blocks.blocks)
            {
                spriteBatch.Draw(GeneralBlockSprite, b.Position, Color.Red);
            }
            foreach (Blocks b in Blocks.waterblocks)
            {
                spriteBatch.Draw(GeneralBlockSprite, b.Position, Color.White);
            }
            
            foreach (Door d in Door.leftdoors)
            {
                spriteBatch.Draw(leftDoor, d.Position, Color.White);
            }
            foreach (Door d in Door.rightdoors)
            {
                spriteBatch.Draw(rightDoor, d.Position, Color.White);
            }
            foreach (Door d in Door.downdoors)
            {
                spriteBatch.Draw(downDoor, d.Position, Color.White);
            }

            if (player.Health > 0&& !player.Victory)
            {
                player.anim.Draw(spriteBatch, player.Position,player.Pcolor);
            }
            else if(player.Health<=0&&!player.Victory)
            {
                deadLinkSpin.Draw(spriteBatch, player.Position, Color.White);
                spriteBatch.DrawString(font, "Press R to Reset and Replay", new Vector2(player.camPosition.X - 500, player.camPosition.Y), Color.Red);
                MySounds.dead.Play();
            }
            if (player.Victory)
            {
                LinkCheering.Draw(spriteBatch, player.Position, Color.White);
                spriteBatch.DrawString(youWIN, "YOU WIN!", player.Position-new Vector2(200,200), Color.Yellow);
            }
            spriteBatch.Draw(blackHoleSprite, new Vector2(blackHole1.Position.X-30, blackHole1.Position.Y - 30), Color.White);
            spriteBatch.Draw(blackHoleSprite, new Vector2(blackHole2.Position.X - 30, blackHole2.Position.Y - 30), Color.White);
            if (blackHole3 != null && blackHole4 != null)
            {
                spriteBatch.Draw(blackHoleSprite, new Vector2(blackHole3.Position.X - 30, blackHole3.Position.Y - 30), Color.Blue);
                spriteBatch.Draw(blackHoleSprite, new Vector2(blackHole4.Position.X - 30, blackHole4.Position.Y - 30), Color.Yellow);
            spriteBatch.Draw(blackHoleSprite, new Vector2(blackHole5.Position.X - 30, blackHole5.Position.Y - 30), Color.White);
            sokoban.Draw();
            //spriteBatch.Draw(blackHoleSprite, new Vector2(blackHole6.Position.X - 30, blackHole6.Position.Y - 30), Color.White);

            }

            hint.Draw();


            sokoban.BlackDraw();
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
   
    
}
    