using Game2.Sprites.Enemies;
using Game2.Sprites.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Object.Items
{
    class PortalGunHandler
    {
        private float timeLastUpdate = 0f;
        private Dir direction = Dir.Down;
        private Vector2 tempPosition;
        public int monsterType;


        public void Update(GameTime gameTime, Player player)
        {
            foreach (PortalGun p in PortalGun.portalGuns)
            {
                int sum = player.Radius + p.Radius;
                if (Vector2.Distance(player.Position, new Vector2(p.Position.X - 15f, p.Position.Y - 15f)) < sum)
                {
                    p.Collided = true;
                    PortalGun.portalGunSto.Add(new PortalGun(p.Position, direction));


                }

            }

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D textureToDraw, List<Pokeball> pokeballToDraw)
        {
            foreach (Pokeball i in pokeballToDraw)
            {
                spriteBatch.Draw(textureToDraw, i.Position, Color.White);
            }
        }
    }
}
