using Game2.Object.Items;
using Game2.Sprites.Blocks;
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
        private Game1 game;
        private Vector2 camLocation;
        public void CollisionHandle(Player player)
        {
            foreach(Item it in Item.items)
            {
                Type itemType = it.GetType();
                int sum = player.radius + it.Radius;
                if (true)
                {
                    if (Vector2.Distance(player.Position, it.Position) < sum)
                    {
                        it.Collided = true;
                    }
                }
            }
            Item.items.RemoveAll(p => p.Collided);
            foreach (Blocks upblo in Blocks.upblocks)
            {
                int sum = player.radius + upblo.Radius;
                
                    if (Vector2.Distance(player.Position, upblo.Position) < sum)
                    {
                    
                    player.position.Y = player.position.Y - 410;
                    player.camPosition.Y = player.camPosition.Y - 880;


                    }
                
            }
            foreach (Blocks dnblo in Blocks.downblocks)
            {
                int sum = player.radius + dnblo.Radius;

                if (Vector2.Distance(player.Position, dnblo.Position) < sum)
                {

                    player.position.Y = player.position.Y + 410;
                    player.camPosition.Y = player.camPosition.Y + 880;


                }

            }
            foreach (Blocks leblo in Blocks.leftblocks)
            {
                int sum = player.radius + leblo.Radius;

                if (Vector2.Distance(player.Position, leblo.Position) < sum)
                {

                    player.position.X = player.position.X - 410;
                    player.camPosition.X = player.camPosition.X - 1280;


                }

            }
            foreach (Blocks riblo in Blocks.rightblocks)
            {
                int sum = player.radius + riblo.Radius;

                if (Vector2.Distance(player.Position, riblo.Position) < sum)
                {

                    player.position.X = player.position.X + 380;
                    player.camPosition.X = player.camPosition.X + 1280;


                }

            }
        }

    }
}
