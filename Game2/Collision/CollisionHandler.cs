using Game2.Object.Items;
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
        public void CollisionHandle(Player player, HUD myHUD, Game1 game)
        {
            foreach(Item it in Item.items)
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
                
                    if (Vector2.Distance(player.Position, upblo.Position) < sum)
                    {

                    game.ClearContent();
                    game.ReloadContent();


                    player.position.Y = player.position.Y - 1500;
                    player.camPosition.Y = player.camPosition.Y - 2040;


                    myHUD.HeartUP();
                    myHUD.updateMapLoc(myHUD.getMapDestX(), myHUD.getMapDestY() - 2040);
                    myHUD.indexUp();
                    myHUD.KeyNumUp();
                    myHUD.SwordUp();
                    myHUD.ArrowUp();
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

                    myHUD.HeartDown();
                    myHUD.updateMapLoc(myHUD.getMapDestX(), myHUD.getMapDestY() + 2040);
                    myHUD.indexDown();
                    myHUD.KeyNumDown();
                    myHUD.SwordDown();
                    myHUD.ArrowDown();
                }

            }
            foreach (Blocks leblo in Blocks.leftblocks)
            {
                int sum = player.Radius + leblo.Radius;

                if (Vector2.Distance(player.Position, leblo.Position) < sum)
                {
                    game.ClearContent();
                    game.ReloadContent();

                    player.position.X = player.position.X - 300;
                    player.camPosition.X = player.camPosition.X - 1280;
                    myHUD.HeartLeft();
                    myHUD.updateMapLoc(myHUD.getMapDestX() - 1280, myHUD.getMapDestY());
                    myHUD.indexLeft();
                    myHUD.KeyNumLeft();
                    myHUD.SwordLeft();
                    myHUD.ArrowLeft();
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
                    myHUD.HeartRight();
                    myHUD.updateMapLoc(myHUD.getMapDestX() + 1280, myHUD.getMapDestY());
                    myHUD.indexRight();
                    myHUD.KeyNumRight();
                    myHUD.SwordRight();
                    myHUD.ArrowRight();
                }

            }
        }

    }
}
