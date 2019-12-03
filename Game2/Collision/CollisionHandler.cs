using Game2.Object.Items;
using Game2.RandomEvent;
using Game2.Sprites.Blocks;
using Game2.Sprites.Enemies;
using Game2.Sprites.Link;
using HUDManager;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Collision
{
    class CollisionHandler
    {
        int rupyNum = 0;
        int keyNum = 0;
        int bombNum = 0;
        public int rm = 1;
        Random rnd = new Random();
        private BlackHole blackHole1;
        private BlackHole blackHole2;
        public int RM
        {
            get { return rm; }
            set { rm = value; }
        }
        public void CollisionHandle(Player player, HUD myHUD, Game1 game)
        {
            foreach (Item it in Item.items)
            {
                Type itemType = it.GetType();
                int sum = player.Radius + it.Radius;
                if (true)
                {
                    if (Vector2.Distance(player.Position, it.Position) < sum)
                    {
                        it.Collided = true;
                    }
                }
                if(itemType == typeof(Rupy2))
                {
                    rupyNum++;
                }
                if (itemType == typeof(Key2)&&it.Collided)
                {
                    keyNum++;
                    myHUD.KeyNumUpdate(keyNum);
                    player.NumOfKeys = keyNum;
                }
                if (itemType == typeof(Bomb))
                {
                    bombNum+=4;
                    myHUD.BombNumUpdate(bombNum);
                }
                if (itemType == typeof(Triforce2)&&it.Collided)
                {
                    player.Victory = true;
                }
                if(itemType == typeof(Button) && it.Collided)
                {
                    RedKnight.rknights.RemoveAll(k => k.Health > 0);
                    GreenKnight.gknights.RemoveAll(k => k.Health > 0);
                    YellowKnight.yknights.RemoveAll(k => k.Health > 0);
                    BlueKnight.bknights.RemoveAll(k => k.Health > 0);
                    game.ReloadContent();
                }
            }
            Item.items.RemoveAll(p => p.Collided);

            foreach (Enemies en in Enemies.enemies)
            {
                Type itemType = en.GetType();
                int sum = player.Radius + en.Radius;
                if (true)
                {
                    if (Vector2.Distance(player.Position, en.Position) < sum)
                    {
                        en.Collided = true;
                    }
                }
            }
            foreach (Blocks upblo in Blocks.upblocks)
            {
                int sum = player.Radius + upblo.Radius;
                rm = rnd.Next(1, 5);
                if (Vector2.Distance(player.Position, upblo.Position) < sum)
                    {

                    game.ClearContent();
                    game.ReloadContent();


                    player.position.Y = player.position.Y - 1500;
                    player.camPosition.Y = player.camPosition.Y - 2040;

                    switch (rm)
                    {
                        case 1:
                            MySounds.random.Play();
                            player.TempSpeed = 200;
                            SpeedUp.spd.Add(new SpeedUp(new Vector2(player.Position.X-300,player.position.Y-600)));
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 150;
                            }
                            while (rm ==1)
                            {
                                rm=rnd.Next(1, 5);
                            }
                            break;
                        case 2:
                            SlowDown.sld.Add(new SlowDown(new Vector2(player.Position.X - 300, player.position.Y-600)));
                            player.TempSpeed = 100;
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 80;
                            }
                            break;
                        case 3:
                            player.TempSpeed = 200;
                            //tempBlackHole1Position = new Vector2(player.Position.X-300,player.Position.Y);
                            //Game1.TempBlackHole2Position = new Vector2(player.Position.X+300, player.Position.Y-500);
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 80;
                            }
                            break;
                        case 4:
                            player.TempSpeed = 200;
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 80;
                            }
                            break;
                    }


                    myHUD.HeartUP();
                    myHUD.updateMapLoc(myHUD.getMapDestX(), myHUD.getMapDestY() - 2040);
                    myHUD.indexUp();
                    myHUD.KeyNumUp();
                    myHUD.SwordUp();
                    myHUD.ArrowUp();
                    foreach (Bat bf in Bat.batF)
                    {
                        bf.Location = player.Position;
                    }
                    foreach (Knight bf in Knight.knightF)
                    {
                        bf.Location = player.Position;
                    }
                }
                

            }
            foreach (Blocks dnblo in Blocks.downblocks)
            {
                int sum = player.Radius + dnblo.Radius;

                if (Vector2.Distance(player.Position, dnblo.Position) < sum)
                {
                    game.ClearContent();
                    game.ReloadContent();

                    player.position.Y = player.position.Y + 1500;
                    player.camPosition.Y = player.camPosition.Y + 2040;
                    switch (rm)
                    {
                        case 1:
                            MySounds.random.Play();
                            player.TempSpeed = 200;
                            SpeedUp.spd.Add(new SpeedUp(new Vector2(player.Position.X - 300, player.position.Y + 400)));
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 150;
                            }
                            while (rm == 1)
                            {
                                rm = rnd.Next(1, 5);
                            }
                            break;
                        case 2:
                            SlowDown.sld.Add(new SlowDown(new Vector2(player.Position.X - 300, player.position.Y+400)));
                            player.TempSpeed = 100;
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 80;
                            }
                            break;
                        case 3:
                            player.TempSpeed = 200;
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 80;
                            }
                            break;
                        case 4:
                            player.TempSpeed = 200;
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 80;
                            }
                            break;
                    }

                    myHUD.HeartDown();
                    myHUD.updateMapLoc(myHUD.getMapDestX(), myHUD.getMapDestY() + 2040);
                    myHUD.indexDown();
                    myHUD.KeyNumDown();
                    myHUD.SwordDown();
                    myHUD.ArrowDown();
                    foreach (Bat bf in Bat.batF)
                    {
                        bf.Location = player.Position;
                    }
                    foreach (Knight bf in Knight.knightF)
                    {
                        bf.Location = player.Position;
                    }
                }
                

            }
            foreach (Blocks leblo in Blocks.leftblocks)
            {
                int sum = player.Radius + leblo.Radius;

                if (Vector2.Distance(player.Position, leblo.Position) < sum)
                {
                    game.ClearContent();
                    game.ReloadContent();

                    player.position.X = player.position.X - 320;
                    player.camPosition.X = player.camPosition.X - 1280;
                    switch (rm)
                    {
                        case 1:
                            MySounds.random.Play();
                            SpeedUp.spd.Add(new SpeedUp(new Vector2(player.Position.X - 800, player.position.Y - 100)));
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 150;
                            }
                            while (rm == 1)
                            {
                                rm = rnd.Next(1, 5);
                            }
                            player.TempSpeed = 200;
                            break;
                        case 2:
                            SlowDown.sld.Add(new SlowDown(new Vector2(player.Position.X - 600, player.position.Y)));
                            player.TempSpeed = 100;
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 80;
                            }
                            break;
                        case 3:
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 80;
                            }
                            player.TempSpeed = 200;
                            break;
                        case 4:
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 80;
                            }
                            player.TempSpeed = 200;
                            break;
                    }
                    myHUD.HeartLeft();
                    myHUD.updateMapLoc(myHUD.getMapDestX() - 1280, myHUD.getMapDestY());
                    myHUD.indexLeft();
                    myHUD.KeyNumLeft();
                    myHUD.SwordLeft();
                    myHUD.ArrowLeft();
                    foreach (Bat bf in Bat.batF)
                    {
                        bf.Location = player.Position;
                    }
                    foreach (Knight bf in Knight.knightF)
                    {
                        bf.Location = player.Position;
                    }
                }
                

            }
            foreach (Blocks riblo in Blocks.rightblocks)
            {
                int sum = player.Radius + riblo.Radius;

                if (Vector2.Distance(player.Position, riblo.Position) < sum)
                {
                    game.ClearContent();
                    game.ReloadContent();

                    player.position.X = player.position.X + 320;
                    player.camPosition.X = player.camPosition.X + 1280;
                    switch (rm)
                    {
                        case 1:
                            MySounds.random.Play();
                            SpeedUp.spd.Add(new SpeedUp(new Vector2(player.Position.X + 100, player.position.Y - 100)));
                            player.TempSpeed = 200;
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 150;
                            }
                            while (rm == 1)
                            {
                                rm = rnd.Next(1, 5);
                            }
                            break;
                        case 2:
                            SlowDown.sld.Add(new SlowDown(new Vector2(player.Position.X + 300, player.position.Y)));
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 80;
                            }
                            player.TempSpeed = 100;
                            while (rm == 2)
                            {
                                rm = rnd.Next(1, 5);
                            }
                            break;
                        case 3:
                            
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 80;
                            }
                            player.TempSpeed = 200;
                            break;
                        case 4:
                            
                            foreach (Bat bat in Bat.bats)
                            {
                                bat.Speed = 80;
                            }
                            player.TempSpeed = 200;
                            break;
                    }
                    myHUD.HeartRight();
                    myHUD.updateMapLoc(myHUD.getMapDestX() + 1280, myHUD.getMapDestY());
                    myHUD.indexRight();
                    myHUD.KeyNumRight();
                    myHUD.SwordRight();
                    myHUD.ArrowRight();
                    foreach (Bat bf in Bat.batF)
                    {
                        bf.Location = player.Position;
                    }
                    foreach (Knight bf in Knight.knightF)
                    {
                        bf.Location = player.Position;
                    }
                }
                
            }
        }

    }
}
