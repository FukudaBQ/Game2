using Game2.Object.Items;
using Game2.Sprites.Blocks;
using Game2.Sprites.Enemies;
using Game2.Sprites.Link;
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
        public void CollisionHandle(Player player, HUD myHUD)
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
                if (itemType == typeof(Key2))
                {
                    keyNum++;
                }
                if (itemType == typeof(Bomb))
                {
                    bombNum+=4;
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
                    
                    player.position.Y = player.position.Y - 1500;
                    player.camPosition.Y = player.camPosition.Y - 2040;


                    myHUD.updateHeartLoc(myHUD.getDestX(), myHUD.getDestY() - 2040);

                    }
                
            }
            foreach (Blocks dnblo in Blocks.downblocks)
            {
                int sum = player.Radius + dnblo.Radius;

                if (Vector2.Distance(player.Position, dnblo.Position) < sum)
                {

                    player.position.Y = player.position.Y + 1500;
                    player.camPosition.Y = player.camPosition.Y + 2040;

                    myHUD.updateHeartLoc(myHUD.getDestX(), myHUD.getDestY() + 2040);

                }

            }
            foreach (Blocks leblo in Blocks.leftblocks)
            {
                int sum = player.Radius + leblo.Radius;

                if (Vector2.Distance(player.Position, leblo.Position) < sum)
                {

                    player.position.X = player.position.X - 410;
                    player.camPosition.X = player.camPosition.X - 1280;
                    myHUD.updateHeartLoc(myHUD.getDestX() - 1280, myHUD.getDestY());

                }

            }
            foreach (Blocks riblo in Blocks.rightblocks)
            {
                int sum = player.Radius + riblo.Radius;

                if (Vector2.Distance(player.Position, riblo.Position) < sum)
                {

                    player.position.X = player.position.X + 330;
                    player.camPosition.X = player.camPosition.X + 1280;
                    myHUD.updateHeartLoc(myHUD.getDestX() + 1280, myHUD.getDestY());

                }

            }
        }

    }
}
