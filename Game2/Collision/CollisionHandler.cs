using Game2.Object.Items;
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
        public void CollisionHandle(Player player)
        {
            foreach(Item it in Item.items)
            {
                if (it.GetType() == typeof(Fairy2))
                {
                    
                        int sum = player.radius + it.Radius;
                        if (Vector2.Distance(player.Position, it.Position) < sum)
                        {
                            it.Collided = true;
                        }
                }

            }
            Item.items.RemoveAll(p => p.Collided);
        }

    }
}
